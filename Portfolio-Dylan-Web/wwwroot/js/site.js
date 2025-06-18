//script to scroll to sucsses meseage on page load
document.addEventListener("DOMContentLoaded", function () {
    var successMessage = document.getElementById("successMessage");
    if (successMessage) {
        successMessage.scrollIntoView({ behavior: "smooth", block: "start" });
    }
});

// script for page tabs
// Only run tab logic on nav-links inside #account-tabs
const tabsContainer = document.querySelector('#Account-tabs');
if (tabsContainer) {
    const tabs = tabsContainer.querySelectorAll('.nav-link');
    const tabContents = document.querySelectorAll('.tab-content');

    tabs.forEach(tab => {
        tab.addEventListener('click', function (e) {
            e.preventDefault();

            tabs.forEach(t => t.classList.remove('active'));
            tab.classList.add('active');

            const target = tab.getAttribute('href');
            tabContents.forEach(content => {
                content.classList.remove('active');
                if (content.id === target.substring(1)) {
                    content.classList.add('active');
                }
            });
        });
    });
}