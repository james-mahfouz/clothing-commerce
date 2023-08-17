const categories = document.querySelectorAll('.category')

category_width = 100 / categories.length - 0.333
for (const elements of categories) {
    elements.style.width = category_width + "%"
}
