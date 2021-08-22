; (function () {

    const service = document.getElementById('showservice');
    const comment = document.getElementById('showcomment');
    const servicecont = document.querySelector('.service-content');
    const commentcont = document.querySelector('.comment-content');
   

    function showComment() {


    }

    window.onload = function () {
        service.addEventListener('click', function () {
            servicecont.style.display = "";
            commentcont.style.display = "none";
        });
        comment.addEventListener('click', function () {
            servicecont.style.display = "none";
            commentcont.style.display = "";
            showComment();
        });
    }

})();