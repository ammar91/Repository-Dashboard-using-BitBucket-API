

(function () {

    var selectedKind = $('#Kind'),
        selectedPriority = $('#Priority'),
        kindDropdown = $('select[name="Kind"]'),
        priorityDropdown = $('select[name="Priority"]'),

        init = function () {
            setDefaultKindAndPriority();
            onKindSelectChange();
            onPrioritySelectChange();
        },

        setDefaultKindAndPriority = function () {
          
            kindDropdown.find('option[value="' + selectedKind.val() + '"]').prop('selected', true);
            priorityDropdown.find('option[value="' + selectedPriority.val() + '"]').prop('selected', true);
        },

        onKindSelectChange = function () {

            kindDropdown.change(function () {

                kindDropdown.find('option').each(function () {
                    if ($(this).is(':selected')) {
                        selectedKind.val($(this).text());
                    }
                });
            });
        },

        onPrioritySelectChange = function () {

            priorityDropdown.change(function () {

                priorityDropdown.find('option').each(function () {
                    if ($(this).is(':selected')) {
                       
                        selectedPriority.val($(this).text());
                    }
                });
            });
        };

    init();

})();