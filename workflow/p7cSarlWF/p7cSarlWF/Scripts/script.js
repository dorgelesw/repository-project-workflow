$(document).ready(function () {
    $('.delete').on('click', function (event) {
        event.preventDefault();
        var lien = $(this);
        $.confirm({
            title: 'Action critique',
            content: 'Êtes-vous sûr?',
            confirmButton: 'Oui',
            cancelButton: 'Annuler',
            confirmButtonClass: 'btn-warning',
            icon: 'fa fa-question-circle',
            animation: 'scale',
            confirm: function () {
                $.confirm({
                    title: 'Confirmation requise',
                    content: 'Êtes-vous sûr de vouloir continuer ?',
                    confirmButton: 'Oui, Continuer',
                    cancelButton: 'Annuler',
                    icon: 'fa fa-warning',
                    confirmButtonClass: 'btn-danger',
                    animation: 'zoom',
                    confirm: function () {
                        var href = lien.attr("href");
                        new PNotify({
                            title: 'Suppression',
                            text: 'Opération de suppression en cours...',
                            type: 'info',
                            icon: false,
                            animate: {
                                animate: true,
                                in_class: 'zoomInLeft',
                                out_class: 'zoomOutRight'
                            }
                        });
                        window.location = href;
                    }
                });
            }
        });

    });
});