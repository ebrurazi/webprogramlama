// site.js
let cartCount = 0;

function addToCart() {
    cartCount++;
    document.getElementById("cart-count").innerText = cartCount;
}

document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('button.add-to-cart').forEach(function (button) {
        button.addEventListener("click", addToCart);
    });
});
