// Eğer mesaj varsa, 2 saniye sonra kaybolsun
window.onload = function () {
    var successMessage = document.getElementById("successMessage");
    if (successMessage) {
        setTimeout(function () {
            successMessage.style.display = 'none';
        }, 2000); // 2000 milisaniye = 2 saniye
    }
};

function confirmDelete(bookId, bookTitle) {
    if (confirm("'" + bookTitle + "' adlı kitabı silmek istediğinize emin misiniz?")) {
        document.getElementById("deleteForm-" + bookId).submit(); // Formu göndererek silme işlemi yap
    } else {
        window.location.href = "/Book/Index"; // Kullanıcı hayır derse liste sayfasına yönlendir
    }
}

