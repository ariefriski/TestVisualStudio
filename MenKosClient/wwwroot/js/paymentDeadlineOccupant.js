const occupantId = document.getElementById('occupantIdTitle').dataset.occupantid

const smallEl = document.getElementById('infoMessage')

$.ajax({
    url: `https://localhost:7095/api/transaction/paymentdeadline/${occupantId}`,
    type: 'GET',
    contentType: 'application/json',
    success: res => {
        console.log(res)

        const outDate = new Date(res.Data.Payment.Order.OutDate)

        const currentTime = new Date()
        currentTime.setHours(0, 0, 0, 0)
        const currentDate = new Date(currentTime)

        const remainingDay = outDate.getDate() - currentDate.getDate()

        smallEl.textContent = `masa sewa kosan tersisa ${remainingDay} hari lagi!`
    }
})