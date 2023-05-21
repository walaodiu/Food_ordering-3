// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let list = document.querySelectorAll(".list li");
let box = document.querySelectorAll(".box");

list.forEach((el) => {
    el.addEventListener("click", (e) => {
        list.forEach((el1) => {
            el1.style.color = "#000";
        })
        e.target.style.color = "#d4a373"
        box.forEach((el2) => {
            el2.style.display = "none";
        })
        document.querySelectorAll(e.target.dataset.color).forEach((el3) => {
            el3.style.display = "flex";
        })
    })
})