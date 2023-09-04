class CheckboxHandler {
    constructor(checkboxId, inputId) {
        this.checkbox = document.getElementById(checkboxId);
        this.inputField = document.getElementById(inputId);
        this.initEvents();
    }

    initEvents() {
        if (this.checkbox && this.inputField) {
            this.checkbox.addEventListener('change', (e) => {
                if (e.target.checked) {
                    this.inputField.value = ''; // Limpa o campo.
                    this.inputField.setAttribute('disabled', 'disabled'); // Desativa o campo.
                } else {
                    this.inputField.removeAttribute('disabled'); // Reativa o campo.
                }
            });
        }
    }
}

document.addEventListener('DOMContentLoaded', (event) => {
    new CheckboxHandler("btnCurrentJob", "EndDate");
});
