/*const { createApp, ref } = Vue*/
$(document).ready(function () {
    $("#signup-form").validate({
        rules: {
            firstname: "required",
            lastname: "required",
            phone: "required",
            email: {
                required: true,
                email: true
            },
            password: {
                required: true,
                minlength: 5
            },
            confirm_password: {
                required: true,
                minlength: 5,
                equalTo: "#password"
            },
            terms_and_condition: "required"
        },
        messages: {
            firstname: "Please enter your first name",
            lastname: "Please enter your last name",
            phone: "Please enter your phone number",
            email: "Please enter a valid email address",
            password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long"
            },
            confirm_password: {
                required: "Please confirm your password",
                minlength: "Your password must be at least 5 characters long",
                equalTo: "Passwords do not match"
            },
            terms_and_condition: "Please agree to the terms and conditions"
        },
        submitHandler: function (form) {
            // Handle form submission here
            form.submit();
        }
    });
});
createApp({
    setup() {
        const signupEmail = ref('')
        const signupPassword = ref('')
        const confPassword = ref('')
        const fName = ref('')
        const lName = ref('')
        const phoneNumber = ref('')

        async function signup(e) {
            //e.preventDefault()
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
