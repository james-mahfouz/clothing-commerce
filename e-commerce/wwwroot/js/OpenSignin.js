
createApp({
    setup() {
        const userName = ref('')
        const userLName = ref('')
        async function getUser() {
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
                openAccountBig()

            } catch (e) {
                openSignin()
            }
        }

        function logout() {
            localStorage.removeItem("token")
            accountMenuDisplayBig.style.display = 'none';
        }

        cartItems = ref([])
        async function getShoppingCart() {
            try {
                const response = await axios.get("/api/User/get_shopping_cart",
                    {
                        headers: {
                            Authorization: "bearer " + localStorage.getItem("token")
                        }
                    })
                console.log(response)
                cartItems.value = response.data
            } catch (e) {
                console.log(e)
            }
        }
        getShoppingCart()

        function incrementItemQuantity(item) {
            item.quantity++;
        }

        function decrementItemQuantity(item) {
            if (item.quantity && item.quantity > 0) {
                item.quantity--;
            }
        }

        async function removeFromCart(item) {
            try {
                console.log(item.cartId)
                const response = await axios.post(`api/User/remove_product_from_cart/${item.cartId}`,
                    {
                        headers: {
                            Authorization: "bearer " + localStorage.getItem("token")
                        }
                    })
                console.log(response)
            } catch (e) {
                console.log(e)
            }
        }


        function getStyleColor(colorID) {
            if (colorID == 1) {
                return "_d92020"
            } else if (colorID == 2) {
                return "_002bb9"
            } else if (colorID == 3) {
                return "_094816"
            } else if (colorID == 4) {
                return "_ffbe00"
            } else if (colorID == 5) {
                return "_000"
            } else if (colorID == 6) {
                return "_fff"
            } else if (colorID == 7) {
                return "_a60ad4"
            } else if (colorID == 8) {
                return "_ae7400"
            } else if (colorID == 9) {
                return "_ff98b4"
            } else if (colorID == 10) {
                return "_8d6e32"
            } else if (colorID == 11) {
                return "_4a4a4a"
            } else if (colorID == 12) {
                return "_21e6e0"
            } else if (colorID == 13) {
                return "_002bb9"
            } else if (colorID == 14) {
                return "_3f1092"
            }

        }

        return {
            userName,
            userLName,
            getUser,
            logout,
            cartItems,
            getStyleColor,
            incrementItemQuantity,
            decrementItemQuantity,
            removeFromCart
        }
    }
}).mount('#openSignin')


const openSignin = () => {
    signin.style.display = 'flex'
}

const accountMenuDisplayBig = document.getElementById('account-menu-display-big');

const openAccountBig = () => {
    accountMenuDisplayBig.style.display = accountMenuDisplayBig.style.display === 'block' ? 'none' : 'block';
}