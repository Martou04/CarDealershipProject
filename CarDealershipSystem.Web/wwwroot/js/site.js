function statistics() {
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        if ($('#statistics_box').hasClass('d-none')) {
            $.get('https://localhost:7189/api/statistics', function (data) {
                $('#total_cars').text(data.totalCars + " Cars");
                $('#total_sellers').text(data.totalSellers + " Sellers");

                $('#statistics_box').removeClass('d-none');

                $('#statistics_btn').text('Hide Statistics');
                $('#statistics_btn').removeClass('btn-primary');
                $('#statistics_btn').addClass('btn-danger');
            });
        } else {
            $('#statistics_box').addClass('d-none');

            $('#statistics_btn').text('Show Statistics');
            $('#statistics_btn').removeClass('btn-danger');
            $('#statistics_btn').addClass('btn-primary');
        }
    });
}