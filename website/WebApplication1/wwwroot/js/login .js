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
