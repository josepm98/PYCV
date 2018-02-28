UPDATE `playyourcvdatabase`.`categoriapreguntas` SET `CategoriaDePregunta`='intro_objetivo' WHERE `idCategoriaPreguntas`='1';
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('2', 'intro_micv');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('3', 'intro_micv_foto');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('4', 'intro_micv_datospersonales');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('5', 'intro_micv_presentacion');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('6', 'intro_micv_experiencia');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('7', 'intro_micv_educacion');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('8', 'intro_micv_habilidades');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('9', 'intro_micv_formacion');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('10', 'intro_micv_idiomas');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('11', 'intro_micv_datosdeinteres');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('12', 'intro_micv_hobbies');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('13', 'intro_micv_plantilla');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('14', 'intro_app');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('15', 'frases_random');
INSERT INTO `playyourcvdatabase`.`categoriapreguntas` (`idCategoriaPreguntas`, `CategoriaDePregunta`) VALUES ('16', 'frases_inicioapp');


INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('El Curriculum Vitae es una de las herramientas fundamentales para encontrar empleo y darte a conocer profesionalmente. Es la primera impresión que una empresa se va a llevar sobre ti, por eso vamos a esforzanos por hacerlo lo mejor posible.', '2');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Piensa que la persona que este seleccionando personal tiene muy poco tiempo para revisar cada CV, y es por eso, que es primordial que resulte atractivo a primera vista. Esto implica que la plantilla que utilices debería tener cierto encanto y que el contenido tiene que estar correctamente estructurado, ser muy claro y conciso. ', '2');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('¡No te preocupes, con mi ayuda será coser y cantar!', '2');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Una vez has conseguido que se fijen en tu CV es cuando el contenido cobra importancia: los datos que aportas y cómo los cuentas. ¿Empezamos?', '2');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Esta sección, junto con la Presentación, es fundamental para lograr que la persona que está leyendo tu CV “se enamore a primera vista de ti”.', '3');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('No elijas cualquier fotografía. Nada de reciclar. Arréglate y posa. Es importante que tu cara se vea bien y este bien iluminada, mira de frente y sal con un gesto amable. ¡Una sonrisa puede ser irresistible! A ser posible, procura que en la imagen solo aparezcan tu cara y hombros.', '3');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Es importante que tengas tus datos personales actualizados para que puedan contactar contigo fácilmente. Procura que el email que incluyas sea una dirección de correo seria, nada de poner esa cuenta de correo que contiene palabras inapropiadas o graciosas.', '4');
INSERT INTO `playyourcvdatabase`.`dialogos_robot` (`ContenidoSpanish`, `CategoriaPreguntas_idCategoriaPreguntas`) VALUES ('Define cómo eres y qué puedes aportar como profesional. ¿Quién eres? ¿Cuáles son tus puntos fuertes? ¿En que eres diferente al resto? ¿Qué te hace especial?', '5');
