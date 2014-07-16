function createImagesPreviewer(selector, items) {
    var THUMB_SIZE = 200;
    var container = document.querySelector(selector);

    container.style.width = '800px';
    container.style.height = '500px';

    var mainMenu = document.createElement('div');
    mainMenu.id = 'mainMenu';
    mainMenu.style.width = '500px';
    mainMenu.style.height = '500px';
    //    mainMenu.style.border = '1px solid black';
    mainMenu.style.display = 'inline-block';
    mainMenu.style.verticalAlign = 'top';


    var thumb = document.createElement('div');
    thumb.id = 'thumb';
    thumb.style.width = '200px';
    thumb.style.height = '450px';
    //    thumb.style.border = '1px solid black';
    thumb.style.display = 'inline-block';
    thumb.style.overflow = 'auto'
    thumb.style.margin = '50px 0 0 0';

    var finder = document.createElement('div');
    finder.id = 'finder';
    finder.style.width = '120px';
    finder.style.height = '50px';
    finder.style.position = 'absolute';
    finder.style.right = '0px;'
    var finderTitle = document.createElement('p');
    finderTitle.innerHTML = 'Filter';
    finderTitle.style.textAlign = 'center';
    finderTitle.style.margin = '2px';
    finder.appendChild(finderTitle);
    var finderInput = document.createElement('input');
    finder.id = 'finderTxt';
    finderInput.type = 'text';
    finderInput.style.textAlign = 'center';
    finderInput.style.margin = '2px';
    finderInput.addEventListener('keyup', filterThumbs);
    finder.appendChild(finderInput);


    var itemsContainer = document.createDocumentFragment();
    var itemsArray = [];
    for (var i = 0; i < items.length; i++) {
        itemsArray[i] = document.createElement('div');
        itemsArray[i].id = items[i].title;
        //        itemsArray[i].id = 'item' + i;
        itemsArray[i].style.width = '180px';
        itemsArray[i].style.height = '160px';

        var itemsTitle = document.createElement('p')
        itemsTitle.innerHTML = items[i].title;
        itemsTitle.style.textAlign = 'center';
        itemsTitle.style.margin = '2px';
        itemsArray[i].appendChild(itemsTitle);

        var itemImage = document.createElement('img')
        itemImage.src = items[i].url;
        itemImage.style.width = '180px';
        itemImage.style.height = '120px';
        itemsArray[i].appendChild(itemImage);

        itemsArray[i].addEventListener('mouseenter', onMouseIn);
        itemsArray[i].addEventListener('mouseleave', onMouseOut);
        itemsArray[i].addEventListener('click', onMouseClick);

        thumb.appendChild(itemsArray[i]);
    };

    var thumbContainer = document.createElement('div');
    thumbContainer.id = 'thumbContainer';
    thumbContainer.style.width = '200px';
    thumbContainer.style.height = '400px';
    //   thumbContainer.style.border = '1px solid black';
    thumbContainer.style.display = 'inline-block';

    thumbContainer.appendChild(finder);
    thumbContainer.appendChild(thumb);
    container.appendChild(mainMenu);
    container.appendChild(thumbContainer);
    itemsArray[0].click();

    function filterThumbs() {
        var txt = this.value.toLowerCase();
        var thumbs = document.getElementById('thumb');
        for (var i = thumb.children.length - 1; i >= 0; i--) {
            if (txt && thumb.children[i].id.toLowerCase().indexOf(txt) == -1) {
                thumb.children[i].style.display = 'none';
            } else {
                thumb.children[i].style.display = 'inline-block';
            }
        };
        console.log(thumbs);
    }

    function onMouseIn(evt) {
        this.style.backgroundColor = 'lightgray';
    }

    function onMouseOut(evt) {
        this.style.backgroundColor = 'white';
    }

    function onMouseClick(evt) {
        while (mainMenu.hasChildNodes()) {
            mainMenu.removeChild(mainMenu.lastChild);
        }
        var title = this.getElementsByTagName('p')[0];
        var image = this.getElementsByTagName('img')[0];

        var p = document.createElement('p');
        p.innerHTML = title.innerHTML;
        p.style.textAlign = 'center';
        p.style.margin = '2px';
        mainMenu.appendChild(p);
        var img = document.createElement('img');
        img.src = image.src;
        img.style.width = '450px';
        img.style.height = '400px';
        mainMenu.appendChild(img);

    }
}