document.addEventListener('DOMContentLoaded', function() {
    const anchor = document.getElementById('per_user');
    const target = document.getElementById('add_button');
    anchor.addEventListener('click', function(event) {
        event.preventDefault();
        target.style.opacity = '0';
    });
});

document.addEventListener('DOMContentLoaded', function() {
    const anchor = document.getElementById('per_farmer');
    const target = document.getElementById('add_button');
    anchor.addEventListener('click', function(event) {
        event.preventDefault();
        target.style.opacity = '1';
    });
});