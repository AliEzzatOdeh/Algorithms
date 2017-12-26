var menuImage = document.querySelector('.menu-image');
menuImage.onclick = function () {
    document.querySelector('.side-menu').classList.toggle("hidden");
};

var autherImage = document.querySelector('.auther-image');
autherImage.onclick = function () {
    document.querySelector('.auther-menu').classList.toggle("hidden");
};

var sortingCategory = document.getElementById("sortingCategory");
sortingCategory.onclick = function () {
    var sortingElements = document.getElementById("sortingElements");
    sortingElements.classList.toggle("hidden-without-reserved-place");
};