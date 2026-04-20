const password = document.getElementById("register_password")
const min = document.getElementById("min")
const number = document.getElementById("number")
const spec = document.getElementById("spec")
const letter = document.getElementById("letter")

function test() {
    const value = password.value

    if (value.length >= 8) {
        min.classList.remove("text-danger")
        min.classList.add("text-success")
    } else {
        min.classList.remove("text-success")
        min.classList.add("text-danger")
    }

    if (/\d/.test(value)) {
        number.classList.remove("text-danger")
        number.classList.add("text-success")
    } else {
        number.classList.remove("text-success")
        number.classList.add("text-danger")
    }

    if (/[^\w\s]/.test(value)) {
        spec.classList.remove("text-danger")
        spec.classList.add("text-success")
    } else {
        spec.classList.remove("text-success")
        spec.classList.add("text-danger")
    }

    if (/[a-z]/.test(value) && /[A-Z]/.test(value)) {
        letter.classList.remove("text-danger")
        letter.classList.add("text-success")
    } else {
        letter.classList.remove("text-success")
        letter.classList.add("text-danger")
    }
}
