
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
                if (typeof response.data === 'string') {
                    cartItems.value = []
                    totalPrice.value = 0
                } else {
                    cartItems.value = response.data.shoppingCartItems
                    totalPrice.value = response.data.totalPrice
                }

            } catch (e) {
                console.log(e)
            }
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

            } catch (e) {
                console.log(e)
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


        return {
            userName,
            userLName,
            getUser,
            logout,
            cartItems,
            getStyleColor,
            incrementItemQuantity,
            decrementItemQuantity,
            removeFromCart,
            totalPrice,
            checkout
        }
    }
}).mount('#openSignin')


const accountMenuDisplayBig = document.getElementById('account-menu-display-big');

const openAccountBig = () => {
    accountMenuDisplayBig.style.display = accountMenuDisplayBig.style.display === 'block' ? 'none' : 'block';
}

