const smallScreenMenu = document.querySelector('.small-screen-menu');
const openIcon = document.getElementById('open-icon')
const closeIcon = document.getElementById('close-icon')
const goWomen = document.getElementById('go-women');
const backArrow = document.getElementById('back-arrow');
const goClothing = document.getElementById('go-clothing')
const clothingBackArrow = document.getElementById('clothing-back-arrow')
/*const openAccount = document.getElementById('open-account')*/
const openWomenMenu = document.getElementById('women-big-menu-open');
const womenClothingOption = document.getElementsByClassName('women-clothing-option')[0];
const openClothing = document.getElementById('open-clothing')
const bigMenu = document.getElementById('big-menu')
const header2HoverMenuContent = document.getElementsByClassName('header-2-hover-menu-content')[0]
const header2HoverMenuUnderline = document.getElementsByClassName('header-2-hover-menu-underline')[0];


document.addEventListener("DOMContentLoaded", function () {
    const header = document.getElementById("header");

    function checkScrollPosition() {
        const scrollPosition = window.scrollY || document.documentElement.scrollTop;
        const header_1 = document.getElementById("header-1")
        const header_2 = document.getElementById("header-2")

        if (scrollPosition > 0) {
            header_1.style.paddingTop = "1px"
            header_1.style.paddingBottom = "1px"
            header_2.style.height = "50px"
            bigMenu.style.marginTop = "-30px"
        }

        if (scrollPosition == 0) {
            header_1.style.paddingTop = "6px"
            header_1.style.paddingBottom = "7px"
            header_2.style.height = ""
            bigMenu.style.marginTop = ""
        }
    }

    window.addEventListener("scroll", checkScrollPosition);
});

const setDisplayNone = () => {
    womenClothingOption.style.display = 'none';
    header2HoverMenuContent.style.display = 'none';
    header2HoverMenuUnderline.style.display = 'none';
};

openIcon.addEventListener('click', () => {
    smallScreenMenu.classList.toggle('active');
})

closeIcon.addEventListener('click', () => {
    smallScreenMenu.classList.remove('active')
})

goWomen.addEventListener('click', () => {
    document.getElementById('initial-menu').style.display = 'none'
    document.getElementById('women-menu').style.display = 'block'
})

backArrow.addEventListener('click', () => {
    document.getElementById('initial-menu').style.display = 'block'
    document.getElementById('women-menu').style.display = 'none'
})

goClothing.addEventListener('click', () => {
    document.getElementById('women-clothing-menu').style.display = 'block'
    document.getElementById('women-menu').style.display = 'none'
})

clothingBackArrow.addEventListener('click', () => {
    document.getElementById('women-clothing-menu').style.display = 'none'
    document.getElementById('women-menu').style.display = 'block'
})

//openAccount.addEventListener('click', () => {
//    const accountMenuDisplay = document.getElementById('account-menu-display');
//    accountMenuDisplay.style.display = (accountMenuDisplay.style.display === 'block') ? 'none' : 'block';
//})

const openSigin = document.getElementById('open-signin')
const openSignup = document.getElementById('open-signup')
const closeSignin = document.querySelectorAll('.close-signin')
const signin = document.getElementsByClassName('signin-container')[0]
const signup = document.getElementsByClassName('signup-container')[0]

openSignup.addEventListener('click', () => {
    signin.style.display = 'none'
    signup.style.display = 'flex'
})

for (let i = 0; i < closeSignin.length; i++) {
    closeSignin[i].addEventListener('click', () => {
        signin.style.display = 'none'
        signup.style.display = 'none'
    })
}



openWomenMenu.addEventListener('mouseover', () => {
    openWomenMenu.style.borderBottom = '1px solid #000'
    const underline = document.getElementsByClassName('header-2-hover-menu-underline')[0]
    womenClothingOption.style.display = 'flex'
    womenClothingOption.style.maxHeight = womenClothingOption.scrollHeight + 'px';
    womenClothingOption.style.paddingTop = '14px'
    isOpen = true
    underline.style.display = 'block'



    openClothing.addEventListener('mouseover', () => {
        openClothing.style.fontWeight = '900'
        openClothing.style.color = '#000'
        header2HoverMenuContent.style.display = 'flex'
        header2HoverMenuContent.style.maxHeight = header2HoverMenuContent.scrollHeight + 'px';
    })

    openClothing.addEventListener('click', () => {
        window.location.href = "Listing"
    })

    bigMenu.addEventListener('mouseleave', () => {
        openClothing.style.fontWeight = ''
        openClothing.style.color = ''
        openWomenMenu.style.borderBottom = 'none'
        header2HoverMenuContent.style.maxHeight = '0px'
        womenClothingOption.style.maxHeight = '0px'
        setTimeout(setDisplayNone, 300);
    })
})

const cloth_menu = document.querySelectorAll('.cloth-menu p')
for (const element of cloth_menu) {
    if (element.id != 'women-big-menu-open') {
        element.addEventListener('mouseover', function () {
            womenClothingOption.style.maxHeight = '0px';
            openWomenMenu.style.borderBottom = 'none';
            setTimeout(setDisplayNone, 300);
        });
    }
}

const WomenClothingOtherOption = document.querySelectorAll('.women-clothing-option h4')
for (const element of WomenClothingOtherOption) {
    if (element.id != 'open-clothing') {
        element.addEventListener('mouseover', function () {
            header2HoverMenuContent.style.maxHeight = '0px'
            openClothing.style.fontWeight = ''
            openClothing.style.color = ''

            setTimeout(closeMenuContent, 300)
        });
    }
}

function closeMenuContent() {
    header2HoverMenuContent.style.display = 'none';
    header2HoverMenuUnderline.style.display = 'none';
}

window.addEventListener('load', function () {
    document.getElementById('header-search-input').value = '';
});