var heart_button = document.getElementById('heart-button');

heart_button.addEventListener("click", function() {
let counter_value = document.querySelector('.counter');
let count = counter_value.innerHTML;
counter = Number(count)+1;
console.log(counter);
counter_value.innerHTML=counter;
});