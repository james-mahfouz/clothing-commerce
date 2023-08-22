
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
                
            } catch (e) {
                console.log(e)
            }
        }
        return {
            SigninEmail,
            SigninPassword,
            signin
        }
    }
}).mount('#signin')

