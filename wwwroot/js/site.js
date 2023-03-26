// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    LoadProdData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/SignalrServer").build();
    connection.start();

    connection.on("LoadProducts", function () {
        LoadProdData();
    })
    LoadProdData();

    function LoadProdData() {
        console.log('success')
        var tr = '';
        $.ajax({
            url: '/Home/GetProducts',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr +=
                        `<div class="card col-3 mx-3 my-3" style="height: fit-content;">
                            <img class="card-img-top" src="${v.productImage}" alt="Card image cap">
                            <div class="card-body">
                                <h5 class="card-title">${v.productName}</h5>
                                <h6 class="card-subtitle mb-2 text-muted">${v.supplierID}</h6>
                                <p class="card-text">${v.categoryID}</p>
                                <a class="btn btn-primary" href="./Product/Details?id=${v.productID}">Details</a>
                            </div>
                        </div>`
                })
                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }
})