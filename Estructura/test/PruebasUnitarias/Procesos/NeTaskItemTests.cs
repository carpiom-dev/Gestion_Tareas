using Moq;
using Plantilla.Dto.Modelo.Procesos.TaskItem;
using Plantilla.Infraestructura.Modelo.Respuestas;
using Plantilla.Negocio.Procesos.TaskItem;

namespace PruebasUnitarias.Procesos
{
    public class NeTaskItemTests
    {
        private readonly Mock<INeTaskItem> _mockNeTaskItem;

        public NeTaskItemTests()
        {
            _mockNeTaskItem = new Mock<INeTaskItem>();
        }

        [Fact]
        public async Task ConsultarPorId_ShouldReturnTaskItem()
        {
            // Arrange
            var consultarTaskItem = new TaskItemDto.ConsultarTaskItem { Id = 1 };
            var expectedResponse = new RespuestaGenericaConsultaDto<TaskItemDto>
            {
                Respuesta = RespuestaGenericaDto.ExitoComun(),
                Resultado = new TaskItemDto { Id = 1, Titulo = "Test", Descripcion = "Test Description" }
            };

            _mockNeTaskItem.Setup(x => x.ConsultarPorId(consultarTaskItem)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _mockNeTaskItem.Object.ConsultarPorId(consultarTaskItem);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Respuesta.EsExitosa);
            Assert.Equal(1, result.Resultado.Id);
        }

        [Fact]
        public async Task ConsultarTodos_ShouldReturnAllTaskItems()
        {
            // Arrange
            var expectedResponse = new RespuestaGenericaConsultasDto<TaskItemDto>
            {
                Respuesta = RespuestaGenericaDto.ExitoComun(),
                Resultados = new List<TaskItemDto>
                {
                    new TaskItemDto { Id = 1, Titulo = "Test 1", Descripcion = "Test Description 1" },
                    new TaskItemDto { Id = 2, Titulo = "Test 2", Descripcion = "Test Description 2" }
                }
            };

            _mockNeTaskItem.Setup(x => x.ConsultarTodos()).ReturnsAsync(expectedResponse);

            // Act
            var result = await _mockNeTaskItem.Object.ConsultarTodos();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Respuesta.EsExitosa);
            Assert.Equal(2, result.Resultados.Count);
        }

        [Fact]
        public async Task Crear_ShouldReturnSuccess()
        {
            // Arrange
            var crearTaskItem = new TaskItemDto.CrearTaskItem
            {
                Titulo = "New Task",
                Descripcion = "New Description",
                EsCompletada = false // Set the required property
            };
            var expectedResponse = RespuestaGenericaDto.ExitoComun();

            _mockNeTaskItem.Setup(x => x.Crear(crearTaskItem)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _mockNeTaskItem.Object.Crear(crearTaskItem);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.EsExitosa);
        }

        [Fact]
        public async Task Actualizar_ShouldReturnSuccess()
        {
            // Arrange
            var actualizarTaskItem = new TaskItemDto.ActualizarTaskItem
            {
                Id = 1,
                Titulo = "Updated Task",
                Descripcion = "Updated Description",
                EsCompletada = false // Set the required property
            };
            var expectedResponse = RespuestaGenericaDto.ExitoComun();

            _mockNeTaskItem.Setup(x => x.Actualizar(actualizarTaskItem)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _mockNeTaskItem.Object.Actualizar(actualizarTaskItem);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.EsExitosa);
        }

        [Fact]
        public async Task Eliminar_ShouldReturnSuccess()
        {
            // Arrange
            var eliminarTaskItem = new TaskItemDto.EliminarTaskItem { Id = 1 };
            var expectedResponse = RespuestaGenericaDto.ExitoComun();

            _mockNeTaskItem.Setup(x => x.Eliminar(eliminarTaskItem)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _mockNeTaskItem.Object.Eliminar(eliminarTaskItem);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.EsExitosa);
        }
    }
}
