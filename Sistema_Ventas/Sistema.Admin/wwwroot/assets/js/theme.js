(function() {
    window.BlazorMethods = {
        getTable: () => {
            table = $('#MydataTable').DataTable({
                lengthChange: false,
                dom: 'B<"clear">lfrtip',
                buttons: ['excel'],
                destroy: true,
            });
        },
    }
})()
