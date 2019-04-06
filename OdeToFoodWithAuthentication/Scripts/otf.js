$(document).ready(function () {
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
                let $newHtml = $(data);
                $target.replaceWith(newHtml);
                $newHtml.effect("highlight");


            });

            return false;
        };

        let submitAutocompleteForm = function (event, ui) {

            let $input = $(this);

            $input.val(ui.item.label);

            let $form = $input.parents("form:first");

            $form.submit();




        };

        let createAutocomplete = function () {
            let $input = $(this);

            let options = {

                source: $input.attr("data-otf-autocomplete"),
                select: submitAutocompleteForm
            };

            $input.autocomplete(options);

        };

        $("fprm[data-otf-ajax='true']").submit(ajaxFormSubmit);
        $("input[data-otf-autocomplete]").each(createAutocomplete);

    });

});