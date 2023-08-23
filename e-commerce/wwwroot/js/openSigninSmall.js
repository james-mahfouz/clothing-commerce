

createApp({
    setup() {
        const userName = ref('')
        const userLName = ref('')

        async function getUserSmall() {
            try {
                const response = await axios.get("/api/User/get_user",
                    {
                        headers: {
                            Authorization: "bearer " + localStorage.getItem("token")
                        }
                    })
                user_name = response.data.firstName;
                user_l_name = response.data.lastName;
                let firstLetter = user_name.charAt(0)
                const remainingLetters = user_name.substring(1)
                firstLetter = firstLetter.toUpperCase()

                userLName.value = user_l_name.charAt(0).toUpperCase()

                userName.value = firstLetter + remainingLetters
                openAccountSmall()

            } catch (e) {
                openSignin()
            }
        }

        function logout() {
            localStorage.removeItem("token")
            accountMenuDisplaySmall.style.display = 'none';
            const logedout = new CustomEvent('logedout');
            document.dispatchEvent(logedout);
            showSuccessNotification("Logged out successfully")
        }

        return {
            getUserSmall,
            userName,
            userLName,
            logout
        }

    }
}).mount("#openSigninSmall")

const accountMenuDisplaySmall = document.getElementById('account-menu-display');

const openAccountSmall = () => {
    accountMenuDisplaySmall.style.display = accountMenuDisplaySmall.style.display === 'block' ? 'none' : 'block';
}