
const app = createApp({
    setup() {
        const data = ref({
            brandID: [],
            materialID: [],
            minPrice: 0,
            maxPrice:1500
        })
        const items = ref([]);
        const selectedCategory = ref(null)
        const selectedColor = ref(null)
        const selectedSize = ref(null)
        const minSliderValue = Vue.ref(0);
        const maxSliderValue = Vue.ref(1500);
        

        Vue.onMounted(() => {
            $("#slider-range").slider({
                range: true,
                min: 0,
                max: 1500,
                values: [0, 1500],
                slide: function (event, ui) {
                    $("#amount").val(ui.values[0] + " USD - " + ui.values[1] + " USD");
                    $("#min-value").text(ui.values[0] + " USD");
                    $("#max-value").text(ui.values[1] + " USD");

                    let minPosition = (ui.values[0] - $("#slider-range").slider("option", "min")) / ($("#slider-range").slider("option", "max") - $("#slider-range").slider("option", "min")) * 100 - 13;
                    if (minPosition < 3) {
                        minPosition = 0
                    }
                    let maxPosition = (ui.values[1] - $("#slider-range").slider("option", "min")) / ($("#slider-range").slider("option", "max") - $("#slider-range").slider("option", "min")) * 100 - 13;

                    if (maxPosition - minPosition < 26.133) {
                        let space_between = maxPosition - minPosition;
                        let difference = (26.133 - space_between) / 2;
                        maxPosition = maxPosition + difference
                        minPosition = minPosition - difference
                    }
                    
                    $("#min-value").css("left", minPosition + "%");
                    $("#max-value").css("left", maxPosition + "%");
                    data.value.minPrice = ui.values[0]
                    data.value.maxPrice = ui.values[1]
                }
            });
            $("#amount").val($("#slider-range").slider("values", 0) + " USD - " +
                $("#slider-range").slider("values", 1) + " USD");

            $("#min-value").text($("#slider-range").slider("values", 0) + " USD");
            $("#max-value").text($("#slider-range").slider("values", 1) + " USD");
        });

        async function get_product() {
            try {
                let response = await axios.post("/api/Product/get_product", data.value);
                items.value = response.data;
            } catch (e) {
                showErrorNotification("couldn't fetch the product from the database");
            }
        }
        get_product()

        watch(data.value, get_product)

        function changeCategory(category) {
            if (data.value.Category == category) {
                data.value.Category = undefined;
                selectedCategory.value = null;
            } else {
                data.value.Category = category;
                selectedCategory.value = category;
            }

        }

        function changeBrand(brandId) {
            for (let i = 0; i < data.value.brandID.length; i++) {
                if (data.value.brandID[i] == brandId) {
                    data.value.brandID.splice(i, 1)
                    return
                }
            }
            data.value.brandID.push(brandId)
        }

        function changeColor(colorId) {
            if (data.value.ColorID == colorId) {
                data.value.ColorID = undefined
                selectedColor.value = null
            } else {
                data.value.ColorID = colorId
                selectedColor.value = colorId
            }
        }

        function changeSize(sizeId) {
            if (data.value.SizeID == sizeId) {
                data.value.SizeID = undefined
                selectedSize.value = null
            } else {
                data.value.SizeID = sizeId
                selectedSize.value = sizeId
            }
        }

        function changeMaterial(materialId) {
            for (let i = 0; i < data.value.materialID.length; i++) {
                if (data.value.materialID[i] == materialId) {
                    data.value.materialID.splice(i, 1)
                    return
                }
            }
            data.value.materialID.push(materialId)
        }

        function selectSize(item, chosenSize) {
            item.shoppingCartData.size = chosenSize
        }
        async function selectColor(item, chosenColor) {
            item.shoppingCartData.color = chosenColor

            const data = {
                productID: item.productID,
                colorID: chosenColor
            }
            try {
                const response = await axios.post("api/Product/getSizeByColor", data)

                item.itemSize = response.data
            } catch (e) {
                console.log(e)
            }
        }

        function incrementItemQuantity(item) {
            if (item.shoppingCartData.quantity === undefined) {
                item.shoppingCartData.quantity = 1;
            } else {
                item.shoppingCartData.quantity++;
            }
        }

        function decrementItemQuantity(item) {
            if (item.shoppingCartData.quantity && item.shoppingCartData.quantity > 0) {
                item.shoppingCartData.quantity--;
            }
        }

        async function addToCart(item) {
            try {
                await axios.post(`api/User/add_product_to_cart/${item.productID}`, item.shoppingCartData,
                    {
                        headers: {
                            Authorization: "bearer " + localStorage.getItem("token")
                        }
                    })
                const cartChangeEvent = new CustomEvent('cartChange');
                document.dispatchEvent(cartChangeEvent);
                showSuccessNotification("Item added successfully")
            } catch (e) {
                if (e.response.data == "") {
                    showErrorNotification("You should Sign In first")
                } else {
                    showErrorNotification(e.response.data)
                }
               
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
            items,
            changeCategory,
            changeBrand,
            changeColor,
            changeSize,
            changeMaterial,
            incrementItemQuantity,
            decrementItemQuantity,
            selectedCategory,
            selectedColor,
            selectedSize,
            minSliderValue,
            maxSliderValue,
            getStyleColor, 
            selectSize,
            selectColor,
            addToCart
        };
    }
});

app.mount('#listing-container');

