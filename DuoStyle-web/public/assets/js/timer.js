document.addEventListener('DOMContentLoaded', () => {

    let timeLeft = 15 * 60 // 15 perc másodpercben
    const timer = document.getElementById('session-timer')

    // Formátumozó függvény percek és másodpercek megjelenítéséhez
    function formatTime(sec) {
        let m = Math.floor(sec / 60)
        let s = sec % 60
        return (m < 10 ? '0' : '') + m + ':' + (s < 10 ? '0' : '') + s
    }

    if (timer) {
        timer.innerText = `(${formatTime(timeLeft)})`
    }

    // Visszaszámláló indítása
    setInterval(() => {
        timeLeft--

        if (timer) {
            timer.innerText = `(${formatTime(timeLeft)})`
        }

        if (timeLeft <= 0) {
            window.location.href = '/logout'
            return
        }
    }, 1000)

})
