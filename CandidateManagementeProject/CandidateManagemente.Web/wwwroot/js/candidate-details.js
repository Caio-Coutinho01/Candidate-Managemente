document.addEventListener('click', event => {
    const modalLink = event.target.closest('.modal-link');
    if (modalLink) {
        event.preventDefault();

        const url = modalLink.getAttribute('href');
        const modalTitle = modalLink.getAttribute('data-modal-title') || 'Detalhes';

        fetch(url)
            .then(response => response.text())
            .then(data => {
                document.querySelector('#genericModal .modal-body').innerHTML = data;
                document.querySelector('#genericModal .modal-title').innerText = modalTitle;
                const modal = new bootstrap.Modal(document.getElementById('genericModal'));
                modal.show();
            });
    }
});
