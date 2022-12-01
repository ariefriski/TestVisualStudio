console.log("hallo")

$(document).ready(function () {
    $('#paymentTable').DataTable({
        //ajax: {
        //    url: 'https://localhost:7095/api/payment',
        //    dataSrc: 'data'

        //},
        ajax: function (data, callback, settings) {

          

            $.ajax({
                url: 'https://localhost:7095/api/payment',
                type: 'GET',
                dataType: 'json',
                success: function (res) {

                

                    res.data.forEach((element, key) => {
                        $.ajax({
                            url: `https://localhost:7095/api/Order/${element.OrderId}`,
                            async:false,
                            type: 'GET',
                            dataType: 'json',
                            success: function (nextRes) {


                                res.data[key].EntryDate = new Date(nextRes.Data.EntryDate).toLocaleDateString('id-ID', {
                                    weekday: 'long',
                                    year: 'numeric',
                                    month: 'long',
                                    day: 'numeric',
                                });
                                res.data[key].OutDate = new Date(nextRes.Data.OutDate).toLocaleDateString('id-ID', {
                                    weekday: 'long',
                                    year: 'numeric',
                                    month: 'long',
                                    day: 'numeric',
                                });


                            }
                        })



                    });


                    console.log(res.data)


                    callback({ data: res.data })




                }

            })



        },
        columns: [
            {
                data: "Amount",
                render: (data, type, row, meta) => {
                    return data;
                }
            },
            {
                data: 'PaymentDate',
                render: (data) => {
                    return data;
                }
            },
            {
                data: 'Status',
                render: (data) => {
                    return data;
                }
            },
            {
                data: "ProofPayment",
                render: (data) => {
                    return data;
                }
            },
            {
                data: "EntryDate",
                render: (data) => {
                    return data;
                }
            },
            {
                data: "OutDate",
                render: (data) => {
                    return data;
                }
            },

        ],
        dom: 'Bfrtip',
        buttons: {
            buttons: [
                {
                    extend: 'copy',
                    className: 'btn btn-secondary',
                    exportOptions: {
                        columns: [0, 1]
                    }
                },
                { extend: 'colvis', className: 'btn btn-secondary' },
                {
                    extend: 'pdf',
                    className: 'btn btn-secondary',
                    exportOptions: {
                        columns: [0, 1]
                    }
                },
                {
                    extend: 'excel',
                    className: 'btn btn-secondary',
                    exportOptions: {
                        columns: [0, 1]
                    }
                }
            ],
            dom: {
                button: {
                    className: 'btn'
                }
            }
        }

    }

    )

    table.buttons().container().addClass("mb-3 me-3")

})