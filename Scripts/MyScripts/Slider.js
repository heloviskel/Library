var lis = document.getElementsByTagName('li');
for (var i = 0; i < lis.length; i++) {
    lis[i].style.position = 'relative';
    var span = document.createElement('span');
    span.style.cssText = 'position:absolute;left:0;top:0';
    span.innerHTML = i + 1;
    lis[i].appendChild(span);
}

var width = 128; // images width
var count = 2; // images count

var carousel = document.getElementById('carousel');
var list = carousel.querySelector('ul');
var listElems = carousel.querySelectorAll('li');

var position = 0; // present position

carousel.querySelector('.prev').onclick = function () {
    // left sliding
    position = Math.min(position + width * count + 7, 5)
    list.style.marginLeft = position + 'px';
};

carousel.querySelector('.next').onclick = function () {
    // right sliding
    position = Math.max(position - width * count - 11, -width * (listElems.length - count) - 18);
    list.style.marginLeft = position + 'px';
};