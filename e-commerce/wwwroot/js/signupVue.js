/*const { createApp, ref } = Vue*/

createApp({
    setup() {
        const signupEmail = ref('')
        const signupPassword = ref('')
        const confPassword = ref('')
        const fName = ref('')
        const lName = ref('')
        const phoneNumber = ref('')

        async function signup(e) {
            e.preventDefault()
            const data = {
                firstName: fName.value,
                lastName: lName.value,
                phoneNumber: phoneNumber.value,
                email: signupEmail.value,
                password: signupPassword.value,
                confirmPassword: confPassword.value
            }

            try {
                const response = await axios.post('/api/Auth/register', data)
                localStorage.setItem('token', response.data)
                const signup = document.getElementsByClassName('signup-container')[0]
                signup.style.display = 'none'
            } catch (e) {
                console.log(e)
            }
        }
        return {
            fName,
            lName,
            phoneNumber,
            signupEmail,
            signupPassword,
            confPassword,
            signup
        }
    }
}).mount('#signup-form')

