$(function () {

    let ajaxFormSubmit = function () {

        let $form = $(this);

        let options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {

            let $target = $($form.attr("data-otf-target"));
            $target.replace(data);

        });

        return false;
    };

    $("fprm[data-otf-ajax='true']").submit(ajaxFormSubmit);
    
});