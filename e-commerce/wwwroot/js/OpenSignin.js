
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
            loggedIn.value = false
            showSuccessNotification("Logged out successfully")
        }

        cartItems = ref([])
        const totalPrice = ref(0)
        const loggedIn = ref(false)

        async function getShoppingCart() {
            try {
                const response = await axios.get("/api/User/get_shopping_cart",
                    {
                        headers: {
                            Authorization: "bearer " + localStorage.getItem("token")
                        }
                    })
                loggedIn.value = true
                console.log(response)
                if (typeof response.data === 'string') {
                    cartItems.value = []
                    totalPrice.value = 0
                } else {
                    cartItems.value = response.data.shoppingCartItems
                    totalPrice.value = response.data.totalPrice
                }

            } catch (e) {}
        }
        getShoppingCart()

        document.addEventListener('cartChange', () => {
            getShoppingCart()
        });

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
                const response = await axios.post(`api/User/remove_product_from_cart/${item.cartId}`, {},
                    {
                        headers: {
                            Authorization: "bearer " + localStorage.getItem("token")
                        }
                    })
                getShoppingCart()
                showSuccessNotification("Item Removed Succesfully")
            } catch (e) {
                showErrorNotification("could not remove the item from your shopping cart")
            }
        }

        async function checkout() {
            try {
                const response = await axios.get(`api/User/checkout`,
                    {
                        headers: {
                            Authorization: "bearer " + localStorage.getItem("token")
                        }
                    })
                getShoppingCart()
                showSuccessNotification("Checked out successfully")
            } catch (e) {
                showErrorNotification("could not checkout your items")
            }
        }

        $(document).ready(function () {
            $(".popover-trigger").click(function () {
                if (!loggedIn.value) {
                    openSignin();
                } else {
                    $(this).parent().find(".popover-content").toggle();
                }
            });

            $(document).click(function (event) {
                if (!$(event.target).closest(".popover-trigger, .popover-content").length) {
                    $(".popover-content").hide();
                }
            });

            $(".popover-content").click(function (event) {
                event.stopPropagation();
            });
        });

        const openSignin = () => {
            signin.style.display = 'flex'
        }

        document.addEventListener('signedIn', () => {
            loggedIn.value = true
        });

        document.addEventListener('logedout', () => {
            loggedIn.value = false
        });

        return {
            userName,
            userLName,
            getUser,
            logout,
            cartItems,
            incrementItemQuantity,
            decrementItemQuantity,
            removeFromCart,
            totalPrice,
            checkout,
            loggedIn
        }
    }
}).mount('#openSignin')


const accountMenuDisplayBig = document.getElementById('account-menu-display-big');

const openAccountBig = () => {
    accountMenuDisplayBig.style.display = accountMenuDisplayBig.style.display === 'block' ? 'none' : 'block';
}

