const occupantId = document.getElementById('occupantIdTitle').dataset.occupantid

const smallEl = document.getElementById('infoMessage')

$.ajax({
    url: `https://localhost:7095/api/transaction/paymentdeadline/${occupantId}`,
    type: 'GET',
    contentType: 'application/json',
    success: res => {
        console.log(res)

        document.getElementById('extendRoomForm').setAttribute('data-room-id', res.Data.RoomId)
        document.getElementById('extendRoomForm').setAttribute('data-occupant-id', res.Data.Payment.Order.OccupantId)



        const outDate = new Date(res.Data.Payment.Order.OutDate)

        const currentTime = new Date()

        currentTime.setHours(0, 0, 0, 0)
        const currentDate = new Date(currentTime)

        const remainingDay = outDate.getDate() - currentDate.getDate()

        outDateStrLocale = outDate.toLocaleDateString('id-ID', {
            weekday: 'long',
            year: 'numeric',
            month: 'long',
            day: 'numeric',
        })

        smallEl.textContent = `masa sewa kosan tersisa ${remainingDay} hari lagi! (berkahir pada ${outDateStrLocale})`



        //let outDate = new Date(res.Data.Payment.Order.OutDate)

        let roomPrice = res.Data.RoomPrice.Price

        let newEntryDate = new Date(outDate);


        initPopulatedForm(newEntryDate, roomPrice)

    }
})








function initPopulatedForm(inputDateMaybeStr, roomPrice) {
    const inputDate = new Date(inputDateMaybeStr)

    inputDate.setDate(inputDate.getDate() + 1);

    //console.log(lastOutDate)

    const newEntryDate = new Date(inputDate)


    let EntryMonth = `0${newEntryDate.getMonth() + 1}`.slice(-2);
    let EntryDate = `0${newEntryDate.getDate()}`.slice(-2);

    const newEntryDateStr = `${newEntryDate.getFullYear()}-${EntryMonth}-${EntryDate}`


    let newOutDate = new Date(inputDate);

    newOutDate.setMonth(newOutDate.getMonth() + 1)

    let OutMonth = `0${newOutDate.getMonth() + 1}`.slice(-2);
    let OutDate = `0${newOutDate.getDate()}`.slice(-2);

    const newOutDateStr = `${newOutDate.getFullYear()}-${OutMonth}-${OutDate}`


    document.getElementById('entryDate').value = newEntryDateStr


    document.getElementById('outDate').value = newOutDateStr

    document.getElementById('outDate').setAttribute('data-out-date-str', newOutDateStr)

    document.getElementById('totalAmount').value = roomPrice
    document.getElementById('totalAmount').setAttribute('data-room-price', roomPrice)
}






document.getElementById('rentPeriod').addEventListener('change', changePriceandOutDate)

function changePriceandOutDate() {

    const rentPeriodEl = document.getElementById('rentPeriod')

    const outDateEl = document.getElementById('outDate')

    const roomPriceEl = document.getElementById('totalAmount')

    const rentPeriod = rentPeriodEl.value

    const outDateStr = outDateEl.getAttribute('data-out-date-str')

    const roomPrice = roomPriceEl.getAttribute('data-room-price')


    const outDate = new Date(outDateStr)

    outDate.setMonth(outDate.getMonth() - 1 + +rentPeriod)


    let resultMonth = `0${outDate.getMonth() + 1}`.slice(-2);
    let resultDate = `0${outDate.getDate()}`.slice(-2);

    outDateEl.value = `${outDate.getFullYear()}-${resultMonth}-${resultDate}`

    roomPriceEl.value = +roomPrice * rentPeriod

}


//perpanjang sewa kamar
document.getElementById('extendRoomForm').addEventListener('submit', sendExtendRoomRequest)

function sendExtendRoomRequest(event) {
    event.preventDefault();

    const entryDateVal = document.getElementById('entryDate').value
    //const rentPeriodVal = document.getElementById('rentPeriod').value
    const outDateVal = document.getElementById('outDate').value
    const totalAmountVal = document.getElementById('totalAmount').value
    const paymentDateVal = document.getElementById('paymentDate').value
    const proofPaymentFileName = document.getElementById('proofPayment').files[0].name 
    const occupantIdVal = document.getElementById('extendRoomForm').getAttribute('data-occupant-id')
    const roomIdval = document.getElementById('extendRoomForm').getAttribute('data-room-id')

    const data = {
        OccupantId: occupantIdVal,
        EntryDate: entryDateVal,
        OutDate: outDateVal,
        RoomId: roomIdval,
        Amount: totalAmountVal,
        PaymentDate: paymentDateVal,
        ProofPayment: proofPaymentFileName
    }

    console.log(data)

    $.ajax({
        url: `https://localhost:7095/api/transaction/extendtransaction`,
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: res => console.log(res)
    })
}




