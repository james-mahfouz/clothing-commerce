
const app = createApp({
    setup() {
        const data = ref({
            brandID: [],
            materialID: [],
            minPrice: 0,
            maxPrice: 10000
        })
        const items = ref([]);
        const selectedCategory = ref(null)
        const selectedColor = ref(null)
        const selectedSize = ref(null)
        const minSliderValue = Vue.ref(0);
        const maxSliderValue = Vue.ref(1500);
        const categories = ref([])
        const brands = ref([])
        const colors = ref([])
        const sizes = ref([])
        const materials = ref([])
        let filteredbyPrice = ref(false)

        async function get_product() {
            try {
                let response = await axios.post("/api/Product/get_product", data.value);
                items.value = response.data;
                if (!filteredbyPrice.value) {
                    getHighestPrice()
                }
            } catch (e) {
                showErrorNotification("couldn't fetch the product from the database");
            }
        }
        get_product()

        watch(data.value, get_product)
        
        function getHighestPrice() {
            let highestPrice = 0
            for (const item of items.value) {
                if (item.price > highestPrice) {
                    highestPrice = item.price + 1
                }
            }
            $("#slider-range").slider({
                range: true,
                min: 0,
                max: highestPrice,
                values: [0, highestPrice],
                slide: function (event, ui) {
                    filteredbyPrice.value = true
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
        }

        async function getCategories() {
            try {
                const response = await axios.get("api/Product/get_categories")
                categories.value = response.data
            } catch (e) {
                showErrorNotification("unexpected Error happened")
            }
        }
        getCategories()

        async function getBrands() {
            try {
                const response = await axios.get("api/Product/get_brand")
                brands.value = response.data
            } catch (e) {
                showErrorNotification("unexpected Error happened")
            }
        }
        getBrands()

        async function getColors() {
            try {
                const response = await axios.get("api/Product/get_colors")
                colors.value = response.data
            } catch (e) {
                showErrorNotification("unexpected Error happened")
            }
        }
        getColors()

        async function getSizes() {
            try {
                const response = await axios.get("api/Product/get_size")
                sizes.value = response.data
            } catch (e) {
                showErrorNotification("unexpected Error happened")
            }
        }
        getSizes()

        async function getMaterials() {
            try {
                const response = await axios.get("api/Product/get_material")
                materials.value = response.data
            } catch (e) {
                showErrorNotification("unexpected Error happened")
            }
        }
        getMaterials()

        function changeCategory(category) {
            filteredbyPrice.value = false
            data.value.maxPrice = 10000
            if (data.value.CategoryID == category) {
                data.value.CategoryID = undefined;
                selectedCategory.value = null;
            } else {
                data.value.CategoryID = category;
                selectedCategory.value = category;
            }
        }

        function changeBrand(brandId) {
            filteredbyPrice.value = false
            data.value.maxPrice = 10000
            for (let i = 0; i < data.value.brandID.length; i++) {
                if (data.value.brandID[i] == brandId) {
                    data.value.brandID.splice(i, 1)
                    return
                }
            }
            data.value.brandID.push(brandId)
        }

        function changeColor(colorId) {
            filteredbyPrice.value = false
            data.value.maxPrice = 10000
            if (data.value.ColorID == colorId) {
                data.value.ColorID = undefined
                selectedColor.value = null
            } else {
                data.value.ColorID = colorId
                selectedColor.value = colorId
            }
        }

        function changeSize(sizeId) {
            filteredbyPrice.value = false
            data.value.maxPrice = 10000
            if (data.value.SizeID == sizeId) {
                data.value.SizeID = undefined
                selectedSize.value = null
            } else {
                data.value.SizeID = sizeId
                selectedSize.value = sizeId
            }
        }

        function changeMaterial(materialId) {
            filteredbyPrice.value = false
            data.value.maxPrice = 10000
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
            selectSize,
            selectColor,
            addToCart,
            categories,
            brands,
            colors,
            sizes,
            materials
        };
    }
});

app.mount('#listing-container');

