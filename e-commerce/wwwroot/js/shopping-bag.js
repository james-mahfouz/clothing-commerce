
createApp({
    setup() {

        const cartItems = ref([])
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
                const cartChangeEvent = new CustomEvent('cartChange');
                document.dispatchEvent(cartChangeEvent);
                showSuccessNotification("Checked out successfully")
            } catch (e) {
                showErrorNotification("could not checkout your items")
            }
        }

        document.addEventListener('signedIn', () => {
            loggedIn.value = true
        });

        return {
            cartItems,
            incrementItemQuantity,
            decrementItemQuantity,
            removeFromCart,
            totalPrice,
            checkout,
            loggedIn
        }
    }
}).mount('#shopping-bag')

