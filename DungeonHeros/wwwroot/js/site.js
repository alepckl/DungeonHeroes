// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onStaminaChanged() {
    let staminaValue = document.getElementById('inputStamina');
    let strengthValue = document.getElementById('inputStrength');
    
    // Je ne sais pas pourquoi le switch n'allait pas ? 
    if (staminaValue.value >= 7) {
        strengthValue.value = 0;
        staminaValue.value = 7;
    } else if (staminaValue.value == 6) {
        strengthValue.value = 1;
    } else if (staminaValue.value == 5) {
        strengthValue.value = 2;
    } else if (staminaValue.value == 4) {
        strengthValue.value = 3;
    } else if (staminaValue.value == 3) {
        strengthValue.value = 4;
    } else if (staminaValue.value == 2) {
        strengthValue.value = 5;
    } else if (staminaValue.value == 1) {
        strengthValue.value = 6;
    } else if (staminaValue.value == 0) {
        strengthValue.value = 7;
    }
}

function onStrengthChanged() {
    let strengthVal = document.getElementById('inputStrength');
    let staminaVal = document.getElementById('inputStamina');
    
    // Je ne sais pas pourquoi le switch n'allait pas ? 
    if (strengthVal.value >= 7) {
        staminaVal.value = 0;
        strengthVal.value = 7;
    } else if (strengthVal.value == 6) {
        staminaVal.value = 1;
    } else if (strengthVal.value == 5) {
        staminaVal.value = 2;
    } else if (strengthVal.value == 4) {
        staminaVal.value = 3;
    } else if (strengthVal.value == 3) {
        staminaVal.value = 4;
    } else if (strengthVal.value == 2) {
        staminaVal.value = 5;
    } else if (strengthVal.value == 1) {
        staminaVal.value = 6;
    } else if (strengthVal.value == 0) {
        staminaVal.value = 7;
    }
}
