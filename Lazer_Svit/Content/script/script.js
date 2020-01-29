AOS.init();
// You can also pass an optional settings object
// below listed default settings
AOS.init({
  // Global settings:
  disable: 'phone', // accepts following values: 'phone', 'tablet', 'mobile', boolean, expression or function
  startEvent: 'DOMContentLoaded', // name of the event dispatched on the document, that AOS should initialize on
  initClassName: 'aos-init', // class applied after initialization
  animatedClassName: 'aos-animate', // class applied on animation
  useClassNames: false, // if true, will add content of `data-aos` as classes on scroll
  disableMutationObserver: false, // disables automatic mutations' detections (advanced)
  debounceDelay: 50, // the delay on debounce used while resizing window (advanced)
  throttleDelay: 99, // the delay on throttle used while scrolling the page (advanced)
  // Settings that can be overridden on per-element basis, by `data-aos-*` attributes:
  offset: 30, // offset (in px) from the original trigger point
  delay: 300, // values from 0 to 3000, with step 50ms
  duration: 600, // values from 0 to 3000, with step 50ms
  easing: 'ease', // default easing for AOS animations
  once: true, // whether animation should happen only once - while scrolling down
  mirror: false, // whether elements should animate out while scrolling past them
  anchorPlacement: 'top-bottom', // defines which position of the element regarding to window should trigger the animation

});

let cartCounter = $('.hopping-cart__counter');

udateCartCounter();
$(".item__plus").click(function(){
  setTimeout(udateCartCounter,500);
})
$('.input_value').bind("keydown change keyup input click", function () {
    setTimeout(udateCartCounter, 500);
})
$(".item__minus").click(function(){
  setTimeout(udateCartCounter,500);
})
$(".add-to-cart").click(function(){
  setTimeout(udateCartCounter,500);
})
$(".remove__link").click(function(){
  setTimeout(udateCartCounter,500);
})

function udateCartCounter(){
  let cartValue = document.cookie.match(new RegExp("(?:^|; )" + "QuantityCookie".replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"))
  if (cartValue !== null){  
    if ( cartCounter.is('.counter__show')) 
    {    
      cartCounter.text(cartValue[1]);
    } 
    else
    {
      cartCounter.addClass('counter__show');
      cartCounter.text(cartValue[1]);
    }
  }
  else
  {
    cartCounter.removeClass('counter__show');
    cartCounter.text("");
  }
}


let headerPopup = $(".header-popup");
let headerPopupToggle = $(".header-popup__toggle");
headerPopupToggle.click(function(){   
  $('.header-popup').addClass('header-popup__show'); 
});
  $(document).mouseup(function (e){   
    if (!headerPopup.is(e.target)
        && headerPopup.has(e.target).length === 0){
      $('.header-popup').removeClass('header-popup__show');
    }   
});


$(".sort-toggle").click(function(){      
  $(".sort__list").toggle();  
});
$(".sort__item").click(function(){
  $('.sort__item').removeClass('selected');   
  $(".sort-toggle").html($(this).html());   
  $(this).addClass('selected');   
  $(this).parents(".sort__list").hide();
});
$(document).bind('click', function(e){
  if (! $(e.target).parents().hasClass("sort-dropdown")) $(".sort__list").hide();
});


let menuToggle = $(".menu-toggle");
let mainMenu = $(".nav");

menuToggle.click(function(){
  menuToggle.toggleClass('toggle__active');
  mainMenu.toggleClass('nav-active');
})

$(document).click(function (e){
  if (!mainMenu.is(e.target) && mainMenu.has(e.target).length === 0 && !menuToggle.is(e.target) && menuToggle.has(e.target).length === 0) {
    menuToggle.removeClass('toggle__active');
    mainMenu.removeClass('nav-active');
  }
});

$('.main-menu-list li').click(function(){
  menuToggle.removeClass('toggle__active');
  mainMenu.removeClass('nav-active');
}); 
$('input[type="file"]').change(function(){
  var value = $(this).val().match(/[^\\]+$/)[0];
  $(this).siblings().eq(0).text(value);
});

let langValue = document.cookie.match(new RegExp("(?:^|; )" + "lang".replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"))
if (langValue != null)
{
    if (langValue[1] == "ru") {
        $(".lang-switcher").eq(0).addClass("lang-switcher__current");
    }
    else if (langValue[1] == "uk") {
        $(".lang-switcher").eq(1).addClass("lang-switcher__current");
    }
    else if (langValue[1] == "en") {
        $(".lang-switcher").eq(2).addClass("lang-switcher__current");
    }
}
else
{
    $(".lang-switcher").eq(0).addClass( "lang-switcher__current");
}

$(".btn-secondary").click(function () {
    location.reload();
})

$(document).bind('click', function (e) {
    if ($(e.target).hasClass("alert-wraper") || $(e.target).hasClass("close__alert")) {
        $(".alert-wraper").detach();
    }
    else if ($(e.target).hasClass("fast-buy__close") || $(e.target).hasClass("fast-buy-wraper")) {
        $(".fast-buy-wraper").hide();
    }
});


$(".add-to-cart__fast").click(function () {
    $(".fast-buy-wraper").show();
    $(".fast-buy__form .tel__error-message").hide();
});
let errorTel = false;
$('.fast-buy__form .form-input__tel').focusout(function () {
    checkTel();
});
$(".fast-buy__button").click(function () {
    checkTel();
    if (errorTel == true) {
        return false;
    }
});
$('.fast-buy__form .form-input__tel').bind("change keyup input click", function () {
    if (this.value.match(/[^0-9 +]/g)) {
        this.value = this.value.replace(/[^0-9 +]/g, '');
    }
});
function checkTel() {
    let messageText = $(".fast-buy-wraper .form-input__tel").val().length;
    if (messageText >= 1) {
        errorTel = false;
        $(".fast-buy__form .tel__error-message").fadeOut(1000);
    } else {
        errorTel = true;
        $(".fast-buy__form .tel__error-message").fadeIn(1000);
    }
}

$(".product-count .input_value").bind("keydown change keyup input click", function () {
    let thisVal = $(this).val();
    if (this.value.match(/[^0-9]/g)) {
        this.value = this.value.replace(/[^0-9]/g, '');
    }
    else if (this.value.match(/[^0-9]|^0{1}/g)) {
        this.value = this.value.replace(/^0+/, '');
    }
});

$(".product-count .item__plus").click(function () {
    let input = $(this).siblings('.input_value');
    let inputValue = $(this).siblings('.input_value').val();

    inputValue = parseFloat(inputValue) + 1;
    input.val(inputValue);
});

$(".product-count .item__minus").click(function () {
    let input = $(this).siblings('.input_value');
    let inputValue = $(this).siblings('.input_value').val();
    if (inputValue > 1) {
        inputValue = parseFloat(inputValue) - 1;
        input.val(inputValue);
    }
});
