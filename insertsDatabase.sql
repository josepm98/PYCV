/*categorias*/
INSERT INTO `playyourcvdatabase`.`categorias` (`Nombre`) VALUES ('DatosPersonales');
INSERT INTO `playyourcvdatabase`.`categorias` (`Nombre`) VALUES ('Estudios');
INSERT INTO `playyourcvdatabase`.`categorias` (`Nombre`) VALUES ('Idiomas');
INSERT INTO `playyourcvdatabase`.`categorias` (`Nombre`) VALUES ('Hobbies');
INSERT INTO `playyourcvdatabase`.`categorias` (`Nombre`) VALUES ('Presentacion');
INSERT INTO `playyourcvdatabase`.`categorias` (`Nombre`) VALUES ('Habilidades');
INSERT INTO `playyourcvdatabase`.`categorias` (`Nombre`) VALUES ('Experiencia');
INSERT INTO `playyourcvdatabase`.`categorias` (`Nombre`) VALUES ('DatosAdicionales');

/*contenidos*/
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`, `Empresa_Escuela`, `Lugar`, `FechaInicio`, `FechaFin`) VALUES ('1', '2', 'Grado en Economía', 'Universitat Pompeu Fabra', 'Barcelona', '2010-09-12', '2014-02-01');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`, `Hablado`, `Escrito`, `Leido`, `NivelGeneral`) VALUES ('1', '3', 'Catalán', 'Nativo', 'Alto', 'Alto', 'C');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`) VALUES ('1', '4', 'Fotografía');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`) VALUES ('1', '4', 'Atletismo');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Descripcion`) VALUES ('1', '5', 'Soy una persona sociable y dinámica. Me encanta trabajar en equipo blablablablablablablablablablablablabla.');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`) VALUES ('1', '6', 'Teamwork');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`) VALUES ('1', '6', 'Contabilidad');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`) VALUES ('1', '6', 'Auditoría contable');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`) VALUES ('1', '6', 'Asesoría fiscal');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`) VALUES ('1', '6', 'Liderazgo');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`, `Descripcion`, `Empresa_Escuela`, `Lugar`, `FechaInicio`, `FechaFin`) VALUES ('1', '7', 'Asesora Fiscal', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In magna massa, varius sed ultricies ut, posuere at sem. Sed lacinia efficitur risus, vel fringilla mauris varius non. Ut molestie, ligula in semper fringilla, urna felis scelerisque est, at consequat eros diam eget purus. Etiam ut pharetra turpis. Integer blandit nisi quam, a tristique orci malesuada ac. Cras vel dui enim. Nunc ut sodales felis. Donec eget gravida nunc. Vestibulum sollicitudin et ex eu sodales. Ut non magna quam. Suspendisse vitae nulla sed dolor scelerisque tincidunt. Vestibulum varius efficitur nisi, in fermentum eros ultrices vel. ', 'Excelsia', 'Madrid', '2014-03-01', '2016-01-28');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`, `Descripcion`, `Empresa_Escuela`, `Lugar`, `FechaInicio`, `FechaFin`) VALUES ('1', '7', 'Manager Executive', 'Nunc at tristique erat. Duis in neque gravida, mattis nunc id, consectetur lectus. Aliquam ac vehicula orci, ac semper lectus. Duis dignissim magna sit amet ante luctus laoreet. Donec eget laoreet augue. Nullam est metus, molestie at eros sit amet, ultricies euismod ipsum. Vivamus sollicitudin porttitor velit at consectetur. Nam vel sem id lorem dapibus tempus. ', 'Goldman n Sucks', 'Washington', '2016-02-01', '2018-02-03');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`, `Hablado`, `Escrito`, `Leido`, `NivelGeneral`) VALUES ('1', '3', 'Inglés', 'Alto', 'Alto', 'Alto', 'C');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`) VALUES ('1', '8', 'Disponibilidad para viajar');
INSERT INTO `playyourcvdatabase`.`contenidos` (`idUsuario`, `Categorias_idCategorias`, `Nombre`) VALUES ('1', '8', 'Flexibilidad horaria');

/*categorias dialogos*/
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('2', 'intro_micv');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('3', 'intro_micv_foto');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('4', 'intro_micv_datospersonales');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('5', 'intro_micv_presentacion');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('6', 'intro_micv_experiencia');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('7', 'intro_micv_educacion');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('8', 'intro_micv_habilidades');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('9', 'intro_micv_formacion');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('10', 'intro_micv_idiomas');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('11', 'intro_micv_datosdeinteres');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('12', 'intro_micv_hobbies');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('13', 'intro_micv_plantilla');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('14', 'intro_app');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('15', 'frases_random');
INSERT INTO `playyourcvdatabase`.`categoriadialogos` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('16', 'frases_inicioapp');

/*dialogos robot`*/
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('El Curriculum Vitae es una de las herramientas fundamentales para encontrar empleo y darte a conocer profesionalmente. Es la primera impresión que una empresa se va a llevar sobre ti, por eso vamos a esforzanos por hacerlo lo mejor posible.', '2');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Piensa que la persona que este seleccionando personal tiene muy poco tiempo para revisar cada CV, y es por eso, que es primordial que resulte atractivo a primera vista. Esto implica que la plantilla que utilices debería tener cierto encanto y que el contenido tiene que estar correctamente estructurado, ser muy claro y conciso. ', '2');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('¡No te preocupes, con mi ayuda será coser y cantar!', '2');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Una vez has conseguido que se fijen en tu CV es cuando el contenido cobra importancia: los datos que aportas y cómo los cuentas. ¿Empezamos?', '2');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Esta sección, junto con la Presentación, es fundamental para lograr que la persona que está leyendo tu CV “se enamore a primera vista de ti”.', '3');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('No elijas cualquier fotografía. Nada de reciclar. Arréglate y posa. Es importante que tu cara se vea bien y este bien iluminada, mira de frente y sal con un gesto amable. ¡Una sonrisa puede ser irresistible! A ser posible, procura que en la imagen solo aparezcan tu cara y hombros.', '3');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Es importante que tengas tus datos personales actualizados para que puedan contactar contigo fácilmente. Procura que el email que incluyas sea una dirección de correo seria, nada de poner esa cuenta de correo que contiene palabras inapropiadas o graciosas.', '4');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Define cómo eres y qué puedes aportar como profesional. ¿Quién eres? ¿Cuáles son tus puntos fuertes? ¿En que eres diferente al resto? ¿Qué te hace especial?', '5');