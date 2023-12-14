let categoriaSeleccionada = 'todos';
let carrito = [];

function toggleButton(button) {
    const buttons = document.querySelectorAll('.btn');
    buttons.forEach(btn => btn.classList.remove('active'));

    button.classList.add('active');

    // Obtener la categoría asociada al botón
    categoriaSeleccionada = button.getAttribute('data-categoria');

    // Si se hace clic en el botón del carrito, muestra los productos en el carrito
    if (categoriaSeleccionada === 'carrito') {
        mostrarCarrito();
    } else {
        // Llamar a la función para filtrar productos si no se hace clic en el carrito
        filtrarProductos();
    }
}

function filtrarProductos() {
    const contentContainer = document.getElementById('content-Products');
    contentContainer.innerHTML = ''; // Limpiar el contenido actual

    fetch('http://localhost:5265/api/Producto')
        .then(response => response.json())
        .then(data => {
            data.forEach(producto => {
                // Filtrar productos por categoría
                if (categoriaSeleccionada === 'todos' || producto.categoriaId === categoriaSeleccionada) {
                    const cardDiv = document.createElement('div');
                    cardDiv.classList.add('card');

                    const img = document.createElement('img');
                    img.src = producto.imagen;
                    img.classList.add('card-img-top');
                    img.alt = '...';

                    const cardBody = document.createElement('div');
                    cardBody.classList.add('card-body');

                    const title = document.createElement('h5');
                    title.classList.add('card-title');
                    title.textContent = producto.titulo;

                    const price = document.createElement('p');
                    price.classList.add('card-text');
                    price.textContent = producto.precio;

                    const addButton = document.createElement('a');
                    addButton.href = '#';
                    addButton.classList.add('btn', 'btn-primary');
                    addButton.textContent = 'Agregar';
                    addButton.addEventListener('click', () => agregarAlCarrito(producto));

                    cardBody.appendChild(title);
                    cardBody.appendChild(price);
                    cardBody.appendChild(addButton);

                    cardDiv.appendChild(img);
                    cardDiv.appendChild(cardBody);

                    contentContainer.appendChild(cardDiv);
                }
            });
        })
        .catch(error => {
            console.error('Error al obtener los datos de la API:', error);
        });
}

function agregarAlCarrito(producto) {
    // Agregar el producto al carrito
    carrito.push(producto);

    // Guardar el carrito en el almacenamiento local
    localStorage.setItem('carrito', JSON.stringify(carrito));

    // Actualizar la cantidad de productos en el carrito
    actualizarCarrito();
}

function mostrarCarrito() {
    const contentContainer = document.getElementById('content-Products');
    contentContainer.innerHTML = ''; // Limpiar el contenido actual

    // Obtener los productos del carrito desde el almacenamiento local
    const carritoGuardado = localStorage.getItem('carrito');
    if (carritoGuardado) {
        carrito = JSON.parse(carritoGuardado);

        // Mostrar los productos del carrito
        carrito.forEach(producto => {
            const cardDiv = document.createElement('div');
            cardDiv.classList.add('card');

            const img = document.createElement('img');
            img.src = producto.imagen;
            img.classList.add('card-img-top');
            img.alt = '...';

            const cardBody = document.createElement('div');
            cardBody.classList.add('card-body');

            const title = document.createElement('h5');
            title.classList.add('card-title');
            title.textContent = producto.titulo;

            const price = document.createElement('p');
            price.classList.add('card-text');
            price.textContent = producto.precio;

            cardBody.appendChild(title);
            cardBody.appendChild(price);

            cardDiv.appendChild(img);
            cardDiv.appendChild(cardBody);

            contentContainer.appendChild(cardDiv);
        });
    }
}

function actualizarCarrito() {
    // Cargar el carrito desde el almacenamiento local
    const carritoGuardado = localStorage.getItem('carrito');
    if (carritoGuardado) {
        carrito = JSON.parse(carritoGuardado);
    }

    const cantidadCarritoElement = document.getElementById('cantidad-carrito');

    // Actualizar la cantidad de productos en el carrito
    cantidadCarritoElement.textContent = carrito.length;
}

function reiniciarCarrito() {
  // Limpiar el carrito y el almacenamiento local
  carrito = [];
  localStorage.removeItem('carrito');

  // Actualizar la cantidad de productos en el carrito
  actualizarCarrito();

  // Limpiar la visualización del carrito
  const contentContainer = document.getElementById('content-Products');
  contentContainer.innerHTML = '';
}

// Llamar a la función inicial para cargar todos los productos
filtrarProductos();
// Actualizar el número de productos en el carrito al cargar la página
actualizarCarrito();
