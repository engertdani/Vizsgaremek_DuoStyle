function togglePassword(inputId, iconId) {
    const password = document.getElementById(inputId)
    const icon = document.getElementById(iconId)

    if (password.type === "password") {
        password.type = "text"
        icon.classList.replace("bi-eye", "bi-eye-slash")
    } else {
        password.type = "password"
        icon.classList.replace("bi-eye-slash", "bi-eye")
    }
}
