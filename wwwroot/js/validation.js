document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector('form');

    form.addEventListener('submit', function (e) {
        let isValid = true;
        const maTaiSan = document.querySelector('#MaTaiSan').value;

        if (!maTaiSan) {
            alert('Mã tài sản không được để trống!');
            isValid = false;
        }
        // Thêm kiểm tra cho các trường khác nếu cần

        if (!isValid) {
            e.preventDefault(); // Ngăn chặn gửi form nếu có lỗi
        }
    });
});
