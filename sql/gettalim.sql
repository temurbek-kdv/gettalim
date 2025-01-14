PGDMP         :            	    {            gettalim-db    15.4    15.3 A    p           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            q           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            r           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            s           1262    16424    gettalim-db    DATABASE     y   CREATE DATABASE "gettalim-db" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.UTF-8';
    DROP DATABASE "gettalim-db";
                doadmin    false            �            1259    16425 
   categories    TABLE     �   CREATE TABLE public.categories (
    id bigint NOT NULL,
    name character varying(50) NOT NULL,
    description text,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.categories;
       public         heap    doadmin    false            �            1259    16432    categories_id_seq    SEQUENCE     �   ALTER TABLE public.categories ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.categories_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    214            �            1259    16433    course_benefits    TABLE     �   CREATE TABLE public.course_benefits (
    id bigint NOT NULL,
    name text NOT NULL,
    course_id bigint,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
 #   DROP TABLE public.course_benefits;
       public         heap    doadmin    false            �            1259    16440    course_benefits_id_seq    SEQUENCE     �   ALTER TABLE public.course_benefits ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.course_benefits_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    216            �            1259    16441    course_comments    TABLE     �   CREATE TABLE public.course_comments (
    id bigint NOT NULL,
    comment text NOT NULL,
    student_id bigint,
    course_id bigint,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
 #   DROP TABLE public.course_comments;
       public         heap    doadmin    false            �            1259    16448    course_comments_id_seq    SEQUENCE     �   ALTER TABLE public.course_comments ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.course_comments_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    218            �            1259    16449    course_moduls    TABLE     �   CREATE TABLE public.course_moduls (
    id bigint NOT NULL,
    name text NOT NULL,
    course_id bigint,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
 !   DROP TABLE public.course_moduls;
       public         heap    doadmin    false            �            1259    16456    course_moduls_id_seq    SEQUENCE     �   ALTER TABLE public.course_moduls ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.course_moduls_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    220            �            1259    16457    course_requirments    TABLE     �   CREATE TABLE public.course_requirments (
    id bigint NOT NULL,
    requirment text NOT NULL,
    course_id bigint,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
 &   DROP TABLE public.course_requirments;
       public         heap    doadmin    false            �            1259    16464    course_requirments_id_seq    SEQUENCE     �   ALTER TABLE public.course_requirments ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.course_requirments_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    222            �            1259    16465    courses    TABLE     )  CREATE TABLE public.courses (
    id bigint NOT NULL,
    name text NOT NULL,
    description text,
    information text,
    lessons integer NOT NULL,
    hours double precision NOT NULL,
    level character varying(50) NOT NULL,
    language character varying(50) NOT NULL,
    image_path text NOT NULL,
    price double precision NOT NULL,
    discount_price double precision NOT NULL,
    mentor_id bigint,
    category_id bigint,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.courses;
       public         heap    doadmin    false            �            1259    16472    mentors    TABLE     f  CREATE TABLE public.mentors (
    id bigint NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50) NOT NULL,
    image_path text NOT NULL,
    description text,
    email text NOT NULL,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now(),
    stack text
);
    DROP TABLE public.mentors;
       public         heap    doadmin    false            �            1259    16479    course_viewmodel    VIEW     o  CREATE VIEW public.course_viewmodel AS
 SELECT kurs.id,
    kurs.name,
    kurs.description,
    kurs.information,
    kurs.lessons,
    kurs.hours,
    kurs.level,
    kurs.language,
    kurs.image_path,
    kurs.price,
    kurs.discount_price,
    kurs.mentor_id,
    kurs.category_id,
    kurs.updated_at,
    ustoz.first_name AS mentor,
    req.requirment,
    ben.name AS benefit
   FROM (((public.courses kurs
     JOIN public.course_requirments req ON ((req.course_id = kurs.id)))
     JOIN public.course_benefits ben ON ((ben.course_id = kurs.id)))
     JOIN public.mentors ustoz ON ((kurs.mentor_id = ustoz.id)));
 #   DROP VIEW public.course_viewmodel;
       public          doadmin    false    216    225    225    224    224    224    224    224    224    224    224    224    224    224    224    224    224    222    222    216            �            1259    16484    courses_id_seq    SEQUENCE     �   ALTER TABLE public.courses ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.courses_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    224            �            1259    16485    mentors_id_seq    SEQUENCE     �   ALTER TABLE public.mentors ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.mentors_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    225            �            1259    16486    payment    TABLE     �   CREATE TABLE public.payment (
    id bigint NOT NULL,
    student_id bigint,
    course_id bigint,
    is_paid boolean DEFAULT false,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.payment;
       public         heap    doadmin    false            �            1259    16492    payment_id_seq    SEQUENCE     �   ALTER TABLE public.payment ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.payment_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    229            �            1259    16493    students    TABLE     &  CREATE TABLE public.students (
    id bigint NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50) NOT NULL,
    is_male boolean NOT NULL,
    email text NOT NULL,
    email_confirmed boolean DEFAULT false,
    phone_number character varying(20) NOT NULL,
    image_path text NOT NULL,
    password_hash text NOT NULL,
    salt text NOT NULL,
    identity_role character varying(20) NOT NULL,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.students;
       public         heap    doadmin    false            �            1259    16501    students_id_seq    SEQUENCE     �   ALTER TABLE public.students ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.students_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    231            �            1259    16502    videos    TABLE     #  CREATE TABLE public.videos (
    id bigint NOT NULL,
    name text NOT NULL,
    video_path text NOT NULL,
    length double precision NOT NULL,
    course_modul_id bigint,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.videos;
       public         heap    doadmin    false            �            1259    16509    videos_id_seq    SEQUENCE     �   ALTER TABLE public.videos ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.videos_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          doadmin    false    233            Z          0    16425 
   categories 
   TABLE DATA           S   COPY public.categories (id, name, description, created_at, updated_at) FROM stdin;
    public          doadmin    false    214   �V       \          0    16433    course_benefits 
   TABLE DATA           V   COPY public.course_benefits (id, name, course_id, created_at, updated_at) FROM stdin;
    public          doadmin    false    216   X       ^          0    16441    course_comments 
   TABLE DATA           e   COPY public.course_comments (id, comment, student_id, course_id, created_at, updated_at) FROM stdin;
    public          doadmin    false    218   Y       `          0    16449    course_moduls 
   TABLE DATA           T   COPY public.course_moduls (id, name, course_id, created_at, updated_at) FROM stdin;
    public          doadmin    false    220   �Y       b          0    16457    course_requirments 
   TABLE DATA           _   COPY public.course_requirments (id, requirment, course_id, created_at, updated_at) FROM stdin;
    public          doadmin    false    222   �Z       d          0    16465    courses 
   TABLE DATA           �   COPY public.courses (id, name, description, information, lessons, hours, level, language, image_path, price, discount_price, mentor_id, category_id, created_at, updated_at) FROM stdin;
    public          doadmin    false    224   �[       e          0    16472    mentors 
   TABLE DATA           {   COPY public.mentors (id, first_name, last_name, image_path, description, email, created_at, updated_at, stack) FROM stdin;
    public          doadmin    false    225   3`       h          0    16486    payment 
   TABLE DATA           ]   COPY public.payment (id, student_id, course_id, is_paid, created_at, updated_at) FROM stdin;
    public          doadmin    false    229   ob       j          0    16493    students 
   TABLE DATA           �   COPY public.students (id, first_name, last_name, is_male, email, email_confirmed, phone_number, image_path, password_hash, salt, identity_role, created_at, updated_at) FROM stdin;
    public          doadmin    false    231   �b       l          0    16502    videos 
   TABLE DATA           g   COPY public.videos (id, name, video_path, length, course_modul_id, created_at, updated_at) FROM stdin;
    public          doadmin    false    233   �d       t           0    0    categories_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.categories_id_seq', 11, true);
          public          doadmin    false    215            u           0    0    course_benefits_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.course_benefits_id_seq', 91, true);
          public          doadmin    false    217            v           0    0    course_comments_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.course_comments_id_seq', 12, true);
          public          doadmin    false    219            w           0    0    course_moduls_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.course_moduls_id_seq', 31, true);
          public          doadmin    false    221            x           0    0    course_requirments_id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public.course_requirments_id_seq', 15, true);
          public          doadmin    false    223            y           0    0    courses_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.courses_id_seq', 9, true);
          public          doadmin    false    227            z           0    0    mentors_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.mentors_id_seq', 17, true);
          public          doadmin    false    228            {           0    0    payment_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.payment_id_seq', 5, true);
          public          doadmin    false    230            |           0    0    students_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.students_id_seq', 4, true);
          public          doadmin    false    232            }           0    0    videos_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.videos_id_seq', 3, true);
          public          doadmin    false    234            �           2606    16512    categories categories_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.categories DROP CONSTRAINT categories_pkey;
       public            doadmin    false    214            �           2606    16514 $   course_benefits course_benefits_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.course_benefits
    ADD CONSTRAINT course_benefits_pkey PRIMARY KEY (id);
 N   ALTER TABLE ONLY public.course_benefits DROP CONSTRAINT course_benefits_pkey;
       public            doadmin    false    216            �           2606    16516 $   course_comments course_comments_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.course_comments
    ADD CONSTRAINT course_comments_pkey PRIMARY KEY (id);
 N   ALTER TABLE ONLY public.course_comments DROP CONSTRAINT course_comments_pkey;
       public            doadmin    false    218            �           2606    16518     course_moduls course_moduls_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.course_moduls
    ADD CONSTRAINT course_moduls_pkey PRIMARY KEY (id);
 J   ALTER TABLE ONLY public.course_moduls DROP CONSTRAINT course_moduls_pkey;
       public            doadmin    false    220            �           2606    16520 *   course_requirments course_requirments_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.course_requirments
    ADD CONSTRAINT course_requirments_pkey PRIMARY KEY (id);
 T   ALTER TABLE ONLY public.course_requirments DROP CONSTRAINT course_requirments_pkey;
       public            doadmin    false    222            �           2606    16522    courses courses_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.courses
    ADD CONSTRAINT courses_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.courses DROP CONSTRAINT courses_pkey;
       public            doadmin    false    224            �           2606    16524    mentors mentors_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.mentors
    ADD CONSTRAINT mentors_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.mentors DROP CONSTRAINT mentors_pkey;
       public            doadmin    false    225            �           2606    16526    payment payment_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.payment DROP CONSTRAINT payment_pkey;
       public            doadmin    false    229            �           2606    16528    students students_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.students DROP CONSTRAINT students_pkey;
       public            doadmin    false    231            �           2606    16530    videos videos_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.videos
    ADD CONSTRAINT videos_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.videos DROP CONSTRAINT videos_pkey;
       public            doadmin    false    233            �           2606    16531 .   course_benefits course_benefits_course_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.course_benefits
    ADD CONSTRAINT course_benefits_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.courses(id);
 X   ALTER TABLE ONLY public.course_benefits DROP CONSTRAINT course_benefits_course_id_fkey;
       public          doadmin    false    224    4280    216            �           2606    16536 .   course_comments course_comments_course_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.course_comments
    ADD CONSTRAINT course_comments_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.courses(id);
 X   ALTER TABLE ONLY public.course_comments DROP CONSTRAINT course_comments_course_id_fkey;
       public          doadmin    false    218    224    4280            �           2606    16541 /   course_comments course_comments_student_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.course_comments
    ADD CONSTRAINT course_comments_student_id_fkey FOREIGN KEY (student_id) REFERENCES public.students(id);
 Y   ALTER TABLE ONLY public.course_comments DROP CONSTRAINT course_comments_student_id_fkey;
       public          doadmin    false    231    4286    218            �           2606    16546 *   course_moduls course_moduls_course_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.course_moduls
    ADD CONSTRAINT course_moduls_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.courses(id);
 T   ALTER TABLE ONLY public.course_moduls DROP CONSTRAINT course_moduls_course_id_fkey;
       public          doadmin    false    224    220    4280            �           2606    16551 4   course_requirments course_requirments_course_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.course_requirments
    ADD CONSTRAINT course_requirments_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.courses(id);
 ^   ALTER TABLE ONLY public.course_requirments DROP CONSTRAINT course_requirments_course_id_fkey;
       public          doadmin    false    224    222    4280            �           2606    16556     courses courses_category_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.courses
    ADD CONSTRAINT courses_category_id_fkey FOREIGN KEY (category_id) REFERENCES public.categories(id);
 J   ALTER TABLE ONLY public.courses DROP CONSTRAINT courses_category_id_fkey;
       public          doadmin    false    224    214    4270            �           2606    16561    courses courses_mentor_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.courses
    ADD CONSTRAINT courses_mentor_id_fkey FOREIGN KEY (mentor_id) REFERENCES public.mentors(id);
 H   ALTER TABLE ONLY public.courses DROP CONSTRAINT courses_mentor_id_fkey;
       public          doadmin    false    225    224    4282            �           2606    16566    payment payment_course_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.courses(id);
 H   ALTER TABLE ONLY public.payment DROP CONSTRAINT payment_course_id_fkey;
       public          doadmin    false    4280    224    229            �           2606    16571    payment payment_student_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_student_id_fkey FOREIGN KEY (student_id) REFERENCES public.students(id);
 I   ALTER TABLE ONLY public.payment DROP CONSTRAINT payment_student_id_fkey;
       public          doadmin    false    4286    229    231            �           2606    16576 "   videos videos_course_modul_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.videos
    ADD CONSTRAINT videos_course_modul_id_fkey FOREIGN KEY (course_modul_id) REFERENCES public.course_moduls(id);
 L   ALTER TABLE ONLY public.videos DROP CONSTRAINT videos_course_modul_id_fkey;
       public          doadmin    false    220    233    4276            Z   :  x�uO�r� ����.��p	(S��2�q����}��8�"վ=ޱ�z��g� s6.�&������N�3���h�lӢ��(��ΰ������Z�C���#���O6�M�`pKq �װ��u_Q�㺃!�!c1H;�/9_�1ĩ��`
Ѡ�b��7T &�	�;D8��W��H�SX J�䴦իN���
����d����X���?���������K^��}�vݞv��:sm��lIȕI��#�lp+.��������qq.���@ϳ����^,��7�.����L����b�'���1��7      \   �   x�}νN�0@��~
o�b�{��k�lEH0�D�զM%u�x{@�D�|�O�s�~���n*��T��b��1�PI���LY���fX�ƙJ�Fl��a�I��[��?)�"�h��l%I+��y3��!���:O}�nY#��xM��^�PKNE���4�o(4d��L�VL\I�[�.�x�+؈A���`*I2	�FX����$P̻����qDҀ�[I�EK)��\�      ^   �   x����� �gx��:�pG)�'pwu�Ic�V1`��29(!&������v
��d�q�}�|�a��_1d$I�ҵ$�<T'�Yk���c��I�Gh"�{L��l�}�Q��i�GF(�J�G���~
E�z�lqDv��X ��2Bؖ�ʱ]'Ȑ.�~G*�
}��{R���Ep���-d�      `      x�}��NC!F���t�df`��#��U�n�E��ޛܟT�^ښ����|�o � x�s����a���~���k׵�A�bd��f��	Ű8���4�Z0��m����B@�\HBơ+HS�v�?���d)1�_A�Q�s7��K��GE�0��/�`�Q��Lj�����]I��ľ���.�XA��,a�����ފ���8i��h��������$�ĚDhk}i��niJ�N�E<א�?��-�8}�+H��2��n�v��_~�CY��!�h����;      b   �   x�}�=o� ��~�U�LFp!�c��FI���\%F���)���:E��=G�3-?ϒ�+=�}�a��3�P��d]a���4
����qd_���{�H�F�(��`*irq��:�O4����CөVX���� ���z���[����O͔��$֢���v��a��>0���>9
?���ܫ�6B+��� �-8�&�Vv      d   W  x��V�n�H<S_�7]D�/=��ɮ�`� 9X9#�Mr�"��(��o%�e�{_��aOuuuwщ�]�������`�U��8d��j%Y|�Z�����ӟ"K�e���u�+?U��_&����z*�̗�4���� ��q�G����d���`-���_�b0�Tш�>{��K{s�F
���UK��h���p:r_5���d���f+*��w��r�����(��-W8��V�	�"�j�Æ�Z��X��Q ?[��dE��o�+�U\0u����t%�k�9��(j�[02RP(��qa]�P�_*#)Z�5�'���j��19���m�C��f�@�����ZH��&���i���:\�L{���@%75����NH�9]o7��A��[F�^�HѠ
ps(��Z1`���d��\��zscov�)\S�l�oI�q�$�1�X�
�[�T��D�Ʉ��@]����Z�f	��4q�ð:5٣R�ڌء�Y�F�4�K�Y��N������]�0-�+�wc�����o2p���c�HcU�%r���1��:rv�z=\�-nG����a����喍&�^*ӟ6�,�@i�����R/�#�s����ֲ^d~�~*�勩��'R��<^t���?^�z��p��!E3g1�2������}���$YE ���l�ptk�ue~A���yoz~zQ�6RU�����T�sevN���q-;����%W�]��&�k�ǘXU��W��`>F�D�t�;������=`Y+�]����l� %����q>ܭ�d��i���9�{�g�wУ�k&�4G�O�N����_T| �+��!�?.�3�kp�|ֱ�M���(��n�(G_Z^s.������v�C�����=c7��V姨��e��,lҵvBI����UE������d9��N�@N�fZu���n@�j�[l�s��M���z���l�<iw�<�Ik�)�A*�G3t��ϡG�����]]9��,t�e/�zI|�JOOG[zzr���w�y��$�s?���Q��d���4�"1�Rt��8��G��xAa�J�=i�k�����*�q���S0��ɜ\�      e   ,  x�}�Ko� �מ_����1ث�RU5U�R�����b����ďig~}�L�U��es���M��`H>���>g����L0�u���ӯF5Y	��B�s!J��"X6ZJ���H��KNa@*��8��u:�	#,�D`&�UVVOsJ���j}=�	��!���G�țf7'hQ���p�Ѓ��;�kt��~��};�Ͷ�~Z���3�n߯k_O7����5�1������ǽ�fB����h����q�f��aj�G[�!�h�����FM�uq��ű�Ύ�Kn�!:���0�=���mQ6(քQ�+��U�i��T�.�j�֎s�`4�֣�v��XV\/^����O�3���8�h�9�Y�V�u�Wyr7��9Лp��B���+)\Ҽ`ebJ�`XqUb���42ST���(��i�8�o��!D>��x���/9g͔Uy��<L<�JLؒ�*R���4+�.�|��dEy�%��Q��S�v�`\=S\-m��h
���?dN14Za�E�Э,�3�6c�uw��wF	�������TJ�x�V�"�NW��_�W      h   U   x�}˱�0��p�p|A��1������g2z����@�e�%�\��mL��bov�/dC���8�B��$��^�f~��-�      j   �  x�}�Ko1��Y��l����J)�4o��Rela3���wP�R��=���W�y|F�E�v��� ���E�5�E�J�P��&��m�}9��檥ަU|!,$���*�~ݸ�8����̦��ڵ�,A`���R̄�Xk��G���`���G�gĀq3s4H$'\ � j�ڐg��p[-]���r2բr3�q�`���Zc	��ǐ��;��������O%����ם���*��ڰZd�d�]�]��N���oӗ�H��)��+u�FdH�i���Ht��A�W�?[+�AAxG���Jc!-`���B�R:��*�My6�L�H�&P�|�(`*N	Q�6��y~�����ޖ!�������;\+1h�]V��H�3Hǝ��_����c�?L��(GD
��X�MB9lR_�N%e&����t*./(K�J%,g����4��'���      l   �   x���OK�0��s�*��?M��&�x��u0d��fk�bJ�����EP��|y�}8X�Ƣʞ�a�����m�}()M)�w?�qgɳwԺ�m��r�?�Md�]�n������a�����G$�@0!1+�`��R�4D+-2}!A΂�%W�6���ݠ+��|Ӿ�U:�O�Q��E�3�F�_�	JP��3��І ���3����4��\�B�[!��t`\     