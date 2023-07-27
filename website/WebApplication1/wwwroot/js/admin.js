function switchTab(tabName) {
    var tabButtons = document.getElementsByClassName("tab")[0].getElementsByTagName("button");
    for (var i = 0; i < tabButtons.length; i++) {
        tabButtons[i].classList.remove("active");
    }

    var formGroups = document.getElementsByClassName("form-group");
    for (var i = 0; i < formGroups.length; i++) {
        formGroups[i].classList.remove("active");
    }

    document.getElementById(tabName).classList.add("active");
    event.currentTarget.classList.add("active");
}
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
        categoryButtons.forEach(btn => {
            if (btn !== button) {
                btn.classList.remove('selected');
            }
        });
        button.classList.toggle('selected');
    });
});

heightFilter.addEventListener('input', function () {
    heightValue.textContent = heightFilter.value;
});

widthFilter.addEventListener('input', function () {
    widthValue.textContent = widthFilter.value;
});
function increaseCount() {
    var priceInput = document.getElementById('price');
    var currentValue = parseInt(priceInput.value);
    priceInput.value = currentValue + 1;
}

function decreaseCount() {
    var priceInput = document.getElementById('price');
    var currentValue = parseInt(priceInput.value);
    if (currentValue > 0) {
        priceInput.value = currentValue - 1;
    }
}
document.getElementById("deleteHeightFilter").addEventListener("input", function () {
    var heightValue = document.getElementById("deleteHeightFilter").value;
    document.getElementById("deleteHeightValue").textContent = heightValue;
});

// Function to handle changes in the width slider
document.getElementById("deleteWidthFilter").addEventListener("input", function () {
    var widthValue = document.getElementById("deleteWidthFilter").value;
    document.getElementById("deleteWidthValue").textContent = widthValue;
});