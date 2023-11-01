$(document).ready(function () {
    const popAdd = $(".pop-add");
    const popEdit = $(".pop-edit");
    const popDelete = $(".pop-delete");
    const openPopAdd = $(".btn-blue");
    const openPopEdit = $(".btn-yellow");
    const openPopDelete = $(".btn-red");
    const closePop = $(".close-pop");
    const overlay = $(".overlay");

    function closePopAdds() {
        overlay.addClass("hidden");
        popAdd.addClass("hidden");
    }

    function openPopAdds() {
        overlay.removeClass("hidden");
        popAdd.removeClass("hidden");
    }

    function closePopEdits() {
        overlay.addClass("hidden");
        popEdit.addClass("hidden");
    }

    function openPopEdits() {
        overlay.removeClass("hidden");
        popEdit.removeClass("hidden");
    }

    function closePopDeletes() {
        overlay.addClass("hidden");
        popDelete.addClass("hidden");
    }

    function openPopDeletes() {
        overlay.removeClass("hidden");
        popDelete.removeClass("hidden");
    }

    openPopAdd.click(openPopAdds);
    closePop.click(closePopAdds);
    overlay.click(closePopAdds);

    openPopEdit.click(function () {
        var categoryName = $(this).data('name'); 
        var categoryId = $(this).data('id'); 

        // Set the value of the CategoryName input field in the edit pop-up
        $('#CategoryNameEdit').val(categoryName);
        $('#CategoryIdEdit').val(categoryId);

        // Show the edit pop-up
        openPopEdits();
    });

    closePop.click(closePopEdits);
    overlay.click(closePopEdits);

    $(document).on('keydown', function (e) {
        console.log(e.key);
        if (e.key === 'Escape' && !popUp.hasClass('hidden')) {
            closePops();
        }
    });
    $('.submit-create').click(function (event) {
        var categoryNameValue = $('#CategoryName').val().trim();
        var categoryNameField = $('#CategoryName');
        var errorSpan = categoryNameField.next('.text-danger');

        if (categoryNameValue === '') {
            errorSpan.text('Category Name is required');

            event.preventDefault();
        }
        else if (categoryNameValue.length > 255) {
            errorSpan.text('Category Name must be lower than 255 characters!');
            event.preventDefault();
        }
    });

    $('.submit-edit').click(function (event) {
        var categoryNameValue = $('#CategoryNameEdit').val().trim();
        var categoryNameField = $('#CategoryNameEdit');
        var errorSpan = categoryNameField.next('.text-danger');

        if (categoryNameValue === '') {
            errorSpan.text('Category Name is required');
            event.preventDefault();
        }
        else if (categoryNameValue.length > 255) {
            errorSpan.text('Category Name must be lower than 255 characters!');
            event.preventDefault();
        }
    });


    openPopDelete.click(function () {
        const categoryId = $(this).data('id');
        var $deleteForm = $('#deleteForm');
        if (categoryId) {
            $deleteForm.attr('action', '/Category/Delete/' + categoryId);
            openPopDeletes();
        } else {
            console.error('categoryId is undefined or null.');
        }
    });
    closePop.click(closePopDeletes);
    overlay.click(closePopDeletes);


    closePop.click(closePopDeletes);
    overlay.click(closePopDeletes);
    $(document).ready(function () {
        const content = $('.content');
        const overlay = $('.overlay');

        function updateOverlaySize() {
            const contentWidth = content.width();
            const contentHeight = content.height() + 90;

            overlay.css({
                width: contentWidth,
                height: contentHeight
            });
        }
        updateOverlaySize();
    });
});


