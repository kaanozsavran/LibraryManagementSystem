function confirmDelete(bookId, bookTitle) {
    if (confirm("'" + bookTitle + "' adlı kitabı silmek istediğinize emin misiniz?")) {
        document.getElementById("deleteForm-" + bookId).submit(); // Formu göndererek silme işlemi yap
    } else {
        window.location.href = "/Book/Index"; // Kullanıcı hayır derse liste sayfasına yönlendir
    }
}