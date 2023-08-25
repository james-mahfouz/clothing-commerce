const listing_filter_open = document.getElementById('listing_filter_open')
const close_filters = document.getElementById('close_filters')

listing_filter_open.addEventListener('click', () => {
    document.getElementById('filter').classList.toggle('active');
})

close_filters.addEventListener('click', () => {
    document.getElementById('filter').classList.remove('active')
})

const open_sort_by = document.getElementById('open-sort-by')
const sort_by_header = document.getElementById('sort-by-header')

sort_by_header.addEventListener('click', () => {
    const sortByContent = document.getElementById('sort-by-content')
    if (sortByContent.style.maxHeight) {
        sortByContent.style.maxHeight = ''
        open_sort_by.style.transform = ''
    } else {
        sortByContent.style.maxHeight = '2000px'
        open_sort_by.style.transform = 'rotate(180deg)'
    }
})

const open_brand_filter = document.getElementById('open-brand-filter')
const brand_header = document.getElementById('brand-header')


brand_header.addEventListener('click', () => {
    const brandFilterContent = document.getElementById('brand-filter-content')
    if (brandFilterContent.style.maxHeight) {
        brandFilterContent.style.maxHeight = ''
        open_brand_filter.style.transform = ''
    } else {
        brandFilterContent.style.maxHeight = '2000px'
        open_brand_filter.style.transform = 'rotate(180deg)'
    }
})

const open_color_filter = document.getElementById('open-color-filter')
const color_header = document.getElementById('color-header')


color_header.addEventListener('click', () => {
    const color_filter_Content = document.getElementById('color-filter-content')
    if (color_filter_Content.style.maxHeight) {
        color_filter_Content.style.maxHeight = ''
        open_color_filter.style.transform = ''
    } else {
        color_filter_Content.style.maxHeight = '2000px'
        open_color_filter.style.transform = 'rotate(180deg)'
    }
})

const open_price_filter = document.getElementById('open-price-filter')
const price_header = document.getElementById('price-header')


price_header.addEventListener('click', () => {
    const price_filter_Content = document.getElementById('price-filter-content')
    if (price_filter_Content.style.maxHeight) {
        price_filter_Content.style.maxHeight = ''
        open_price_filter.style.transform = ''
    } else {
        price_filter_Content.style.maxHeight = '10000px'
        open_price_filter.style.transform = 'rotate(180deg)'
    }
})

const open_material_filter = document.getElementById('open-material-filter')
const material_header = document.getElementById('material-header')


material_header.addEventListener('click', () => {
    const material_filter_Content = document.getElementById('material-filter-content')
    if (material_filter_Content.style.maxHeight) {
        material_filter_Content.style.maxHeight = ''
        open_material_filter.style.transform = ''
    } else {
        material_filter_Content.style.maxHeight = '2000px'
        open_material_filter.style.transform = 'rotate(180deg)'
    }
})

const open_size_filter = document.getElementById('open-size-filter')
const size_header = document.getElementById('size-header')


size_header.addEventListener('click', () => {
    const size_filter_Content = document.getElementById('size-filter-content')
    if (size_filter_Content.style.maxHeight) {
        size_filter_Content.style.maxHeight = ''
        open_size_filter.style.transform = ''
    } else {
        size_filter_Content.style.maxHeight = '2000px'
        open_size_filter.style.transform = 'rotate(180deg)'
    }
})

