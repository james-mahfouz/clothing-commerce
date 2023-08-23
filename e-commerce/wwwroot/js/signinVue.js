
createApp({
    setup() {
        const SigninEmail = ref('')
        const SigninPassword = ref('')

        async function signin(e) {
            e.preventDefault()
            const data = {
                email: SigninEmail.value,
                password: SigninPassword.value
            }

            try {
                const response = await axios.post('/api/Auth/login', data)
                localStorage.setItem('token', response.data)
                const signedIn = new CustomEvent('signedIn');
                document.dispatchEvent(signedIn);
                const signin = document.getElementsByClassName('signin-container')[0]
                signin.style.display = 'none'
                showSuccessNotification("Signed In Successfully")

            } catch (e) {
                
                const emailError = e?.response?.data?.errors?.Email?.[0] ?? 'An error occurred'
                const passwordError = e?.response?.data?.errors?.Password?.[0] ?? 'An error occurred'
                console.log(emailError, "hello", passwordError)
                if (emailError != 'An error occurred') {
                    showErrorNotification(emailError)
                } else if (passwordError != 'An error occurred') {
                   showErrorNotification(passwordError)
                }else {
                    showErrorNotification(e.response.data)
                }
            }
        }
        return {
            SigninEmail,
            SigninPassword,
            signin
        }
    }
}).mount('#signin')

