class Validation {

    PriceValidation() {
        const element = document.getElementById('inputPrice') as HTMLInputElement;
        const input: string = element.value;
        const output = document.getElementById('priceValidationMessage');

        if (isNaN(+input)) {
            output.innerHTML = "<span style='color: red'>* Field Price should be Numeric</span>";
        }
        else if (input.length === 0) {
            output.innerHTML = "<span style='color: red'>* Field Price is required</span>";
        }
        else {
            output.innerHTML = '';
        }
    }

    NameValidation() {
        const element = document.getElementById('inputName') as HTMLInputElement;
        const input = element.value;
        const output = document.getElementById('nameValidationMessage');

        if (input.length === 0) {
            output.innerHTML = "<span style='color: red'>* Field Name is required</span>";
        }
        else if (input.length >= 50) {
            output.innerHTML = "<span style='color: red'>* Field Name length should be less than 50</span>";
        }
        else {
            output.innerHTML = '';
        }

        console.log(element.value);
    }

   
    }


window.onload = () => {
    const modal = document.getElementById("myModal") as HTMLElement;
    const modalEdit = document.getElementById("myModalEdit") as HTMLElement;
    const modalDelete = document.getElementById("myModalDelete") as HTMLElement;

    const btn = document.getElementById("myBtn") as HTMLElement;
    const btnEdit = document.getElementById("myBtnEdit") as HTMLElement;
    const btnDelete = document.getElementById("myBtnDelete") as HTMLElement;

    const span = document.getElementsByClassName("close")[0] as HTMLElement;
    const spanCloseEdit = document.getElementById("closeEditMenuItem") as HTMLElement;
    const spanCloseDelete = document.getElementById("closeDeleteMenuItem") as HTMLElement;

    btn.onclick = function () {
        modal.style.display = "block";
    }

    btnEdit.onclick = function () {
        modalEdit.style.display = "block";
    }
    btnDelete.onclick = function () {
        modalDelete.style.display = "block";
    }

    span.onclick = function () {
        modal.style.display = "none";
    }
    spanCloseEdit.onclick = function () {
        modalEdit.style.display = "none";
    }
    spanCloseDelete.onclick = function () {
        modalDelete.style.display = "none";
    }

    window.onclick = function (event) {
        if (event.target === modal) {
            modal.style.display = "none";
        }
    }


    const obj = new Validation();
    const nameInput = document.getElementById('inputName'); // undefined
    const priceInput = document.getElementById('inputPrice');

    if (nameInput !== undefined)
        nameInput.onblur = obj.NameValidation;
    if (priceInput !== undefined)
        priceInput.onblur = obj.PriceValidation;
}