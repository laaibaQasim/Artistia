// Get the modal element
var modal = document.getElementById("cart-modal");

// Get the button that opens the modal
var btn = document.getElementById("add-to-cart-btn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function () {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

//// Get the modal element
//var modal = document.getElementById("myModal");

//// Get the button that opens the modal
//var btn = document.getElementById("openModalButton");

//// Get the <span> element that closes the modal
//var span = document.getElementsByClassName("close")[0];

//// When the user clicks the button, open the modal
//btn.onclick = function () {
//    modal.style.display = "block";
//}

//// When the user clicks on <span> (x), close the modal
//span.onclick = function () {
//    modal.style.display = "none";
//}

//// When the user clicks anywhere outside of the modal, close it
//window.onclick = function (event) {
//    if (event.target == modal) {
//        modal.style.display = "none";
//    }
//}

//// Search button click event
//var searchButton = document.getElementById("searchButton");
//searchButton.onclick = function () {
//    var searchInput = document.getElementById("searchInput").value;
//    // Perform search operation with the searchInput value
//    console.log("Performing search for:", searchInput);
//    // You can add your search logic here
//}

// Get the new modal element
var newModal = document.getElementById("newModal");

// Get the button that opens the new modal
var newBtn = document.getElementById("openNewModalButton");

// Get the <span> element that closes the new modal
var newSpan = document.getElementsByClassName("new-close")[0];

// When the user clicks the button, open the new modal
newBtn.onclick = function () {
    newModal.style.display = "block";
};

// When the user clicks on <span> (x), close the new modal
newSpan.onclick = function () {
    newModal.style.display = "none";
};

// When the user clicks anywhere outside of the new modal, close it
window.onclick = function (event) {
    if (event.target == newModal) {
        newModal.style.display = "none";
    }
};

// New search button click event
var newSearchButton = document.getElementById("new-searchButton");
newSearchButton.onclick = function () {
    var newSearchInput = document.getElementById("new-searchInput").value;
    // Perform search operation with the newSearchInput value
    console.log("Performing search for:", newSearchInput);
    // You can add your search logic here
};



// JavaScript code to handle the selection of buttons and apply styles
const priceFilterButtons = document.querySelectorAll('#priceFilterButtons button');
const categoryButtons = document.querySelectorAll('#categoryFilter button');
const heightFilter = document.getElementById('heightFilter');
const widthFilter = document.getElementById('widthFilter');
const heightValue = document.getElementById('heightValue');
const widthValue = document.getElementById('widthValue');

priceFilterButtons.forEach(button => {
    button.addEventListener('click', function () {
        priceFilterButtons.forEach(btn => {
            btn.classList.remove('selected');
        });
        button.classList.add('selected');
    });
});

categoryButtons.forEach(button => {
    button.addEventListener('click', function () {
        button.classList.toggle('selected');
    });
});

heightFilter.addEventListener('input', function () {
    heightValue.textContent = heightFilter.value;
});

widthFilter.addEventListener('input', function () {
    widthValue.textContent = widthFilter.value;
});
function openWebpage() {
    // Open your webpage here
    window.location.href = "/Index/Index";
}



                            //Added manually
