// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function confirmDeletion(id, entityName, apiEndpoint, redirectUrl) {
    Swal.fire({
        title: `Are You Sure?`,
        text: `You Want to Delete This ${entityName}`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes',
        cancelButtonText: 'Nah'
    }).then((result) => {
        if (result.value) {
            // Perform the deletion action by calling the .NET Core API
            fetch(`${apiEndpoint}?id=${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(response => {
                if (response.ok) {
                    Swal.fire({
                        title: 'Deleted',
                        text: `Selected ${entityName} Has been Deleted`,
                        icon: 'success',
                        timer: 2000,
                        showConfirmButton: false
                    });
                    // Delay the redirection to allow the success message to be displayed
                    setTimeout(() => {
                        window.location = redirectUrl;
                    }, 2000);
                } else {
                    throw new Error('Network response was not ok.');
                }
            }).catch(error => {
                Swal.fire({
                    title: 'Not Deleted',
                    text: `Selected ${entityName} Could Not Be Deleted`,
                    icon: 'error',
                    timer: 2000,
                    showConfirmButton: false
                });
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            // Optionally handle cancel action
        }
    });
}
