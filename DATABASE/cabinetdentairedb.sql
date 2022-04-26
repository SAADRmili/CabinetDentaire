PGDMP                         z            cabinetdentaitedb    14.2    14.2 !    ,           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            -           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            .           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            /           1262    16701    cabinetdentaitedb    DATABASE     n   CREATE DATABASE cabinetdentaitedb WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_Europe.1252';
 !   DROP DATABASE cabinetdentaitedb;
                postgres    false                        3079    16717 	   uuid-ossp 	   EXTENSION     ?   CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA public;
    DROP EXTENSION "uuid-ossp";
                   false            0           0    0    EXTENSION "uuid-ossp"    COMMENT     W   COMMENT ON EXTENSION "uuid-ossp" IS 'generate universally unique identifiers (UUIDs)';
                        false    2            �            1259    16777    appointments    TABLE     �   CREATE TABLE public.appointments (
    id uuid NOT NULL,
    date date NOT NULL,
    dentisteid uuid NOT NULL,
    patientid uuid NOT NULL,
    consultationcategoryid uuid NOT NULL,
    iscancelled boolean DEFAULT false NOT NULL
);
     DROP TABLE public.appointments;
       public         heap    postgres    false            �            1259    16811    cancellations    TABLE     �   CREATE TABLE public.cancellations (
    id uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    date date NOT NULL,
    description text NOT NULL,
    appointmentid uuid NOT NULL
);
 !   DROP TABLE public.cancellations;
       public         heap    postgres    false    2            �            1259    16750    consultationcategories    TABLE     �   CREATE TABLE public.consultationcategories (
    id uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    name character varying(150) NOT NULL,
    price double precision NOT NULL
);
 *   DROP TABLE public.consultationcategories;
       public         heap    postgres    false    2            �            1259    16798    consultations    TABLE     �   CREATE TABLE public.consultations (
    id uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    date date NOT NULL,
    description text NOT NULL,
    appointmentid uuid NOT NULL
);
 !   DROP TABLE public.consultations;
       public         heap    postgres    false    2            �            1259    16739 	   dentistes    TABLE     (  CREATE TABLE public.dentistes (
    id uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    name character varying(150) NOT NULL,
    address character varying(160) NOT NULL,
    email character varying(100) NOT NULL,
    phone character varying(50) NOT NULL,
    workcategoryid uuid NOT NULL
);
    DROP TABLE public.dentistes;
       public         heap    postgres    false    2            �            1259    16728    patients    TABLE     0  CREATE TABLE public.patients (
    id uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    name character varying(50) NOT NULL,
    address character varying(160) NOT NULL,
    email character varying(100) NOT NULL,
    phone character varying(50) NOT NULL,
    grender character varying(50) NOT NULL
);
    DROP TABLE public.patients;
       public         heap    postgres    false    2            �            1259    16734    workcategories    TABLE     �   CREATE TABLE public.workcategories (
    id uuid NOT NULL,
    name character varying(150) NOT NULL,
    hourstartwork time without time zone NOT NULL,
    hourendwork time without time zone NOT NULL
);
 "   DROP TABLE public.workcategories;
       public         heap    postgres    false            '          0    16777    appointments 
   TABLE DATA           l   COPY public.appointments (id, date, dentisteid, patientid, consultationcategoryid, iscancelled) FROM stdin;
    public          postgres    false    214   �*       )          0    16811    cancellations 
   TABLE DATA           M   COPY public.cancellations (id, date, description, appointmentid) FROM stdin;
    public          postgres    false    216   ,0       &          0    16750    consultationcategories 
   TABLE DATA           A   COPY public.consultationcategories (id, name, price) FROM stdin;
    public          postgres    false    213   X1       (          0    16798    consultations 
   TABLE DATA           M   COPY public.consultations (id, date, description, appointmentid) FROM stdin;
    public          postgres    false    215   @2       %          0    16739 	   dentistes 
   TABLE DATA           T   COPY public.dentistes (id, name, address, email, phone, workcategoryid) FROM stdin;
    public          postgres    false    212   23       #          0    16728    patients 
   TABLE DATA           L   COPY public.patients (id, name, address, email, phone, grender) FROM stdin;
    public          postgres    false    210   '4       $          0    16734    workcategories 
   TABLE DATA           N   COPY public.workcategories (id, name, hourstartwork, hourendwork) FROM stdin;
    public          postgres    false    211   �7       �           2606    16782    appointments PK_appointments 
   CONSTRAINT     \   ALTER TABLE ONLY public.appointments
    ADD CONSTRAINT "PK_appointments" PRIMARY KEY (id);
 H   ALTER TABLE ONLY public.appointments DROP CONSTRAINT "PK_appointments";
       public            postgres    false    214            �           2606    16818    cancellations PK_cancellations 
   CONSTRAINT     ^   ALTER TABLE ONLY public.cancellations
    ADD CONSTRAINT "PK_cancellations" PRIMARY KEY (id);
 J   ALTER TABLE ONLY public.cancellations DROP CONSTRAINT "PK_cancellations";
       public            postgres    false    216            �           2606    16755 0   consultationcategories PK_consultationcategories 
   CONSTRAINT     p   ALTER TABLE ONLY public.consultationcategories
    ADD CONSTRAINT "PK_consultationcategories" PRIMARY KEY (id);
 \   ALTER TABLE ONLY public.consultationcategories DROP CONSTRAINT "PK_consultationcategories";
       public            postgres    false    213            �           2606    16805    consultations PK_consultations 
   CONSTRAINT     ^   ALTER TABLE ONLY public.consultations
    ADD CONSTRAINT "PK_consultations" PRIMARY KEY (id);
 J   ALTER TABLE ONLY public.consultations DROP CONSTRAINT "PK_consultations";
       public            postgres    false    215            �           2606    16744    dentistes PK_dentistes 
   CONSTRAINT     V   ALTER TABLE ONLY public.dentistes
    ADD CONSTRAINT "PK_dentistes" PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.dentistes DROP CONSTRAINT "PK_dentistes";
       public            postgres    false    212            �           2606    16733    patients PK_patients 
   CONSTRAINT     T   ALTER TABLE ONLY public.patients
    ADD CONSTRAINT "PK_patients" PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.patients DROP CONSTRAINT "PK_patients";
       public            postgres    false    210            �           2606    16738     workcategories PK_workcategories 
   CONSTRAINT     `   ALTER TABLE ONLY public.workcategories
    ADD CONSTRAINT "PK_workcategories" PRIMARY KEY (id);
 L   ALTER TABLE ONLY public.workcategories DROP CONSTRAINT "PK_workcategories";
       public            postgres    false    211            �           2606    16793 L   appointments FK_appointments_consultationcategoryid_consultationcategories_i    FK CONSTRAINT     �   ALTER TABLE ONLY public.appointments
    ADD CONSTRAINT "FK_appointments_consultationcategoryid_consultationcategories_i" FOREIGN KEY (consultationcategoryid) REFERENCES public.consultationcategories(id);
 x   ALTER TABLE ONLY public.appointments DROP CONSTRAINT "FK_appointments_consultationcategoryid_consultationcategories_i";
       public          postgres    false    213    3211    214            �           2606    16783 4   appointments FK_appointments_dentisteid_dentistes_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.appointments
    ADD CONSTRAINT "FK_appointments_dentisteid_dentistes_id" FOREIGN KEY (dentisteid) REFERENCES public.dentistes(id);
 `   ALTER TABLE ONLY public.appointments DROP CONSTRAINT "FK_appointments_dentisteid_dentistes_id";
       public          postgres    false    212    3209    214            �           2606    16788 2   appointments FK_appointments_patientid_patients_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.appointments
    ADD CONSTRAINT "FK_appointments_patientid_patients_id" FOREIGN KEY (patientid) REFERENCES public.patients(id);
 ^   ALTER TABLE ONLY public.appointments DROP CONSTRAINT "FK_appointments_patientid_patients_id";
       public          postgres    false    214    3205    210            �           2606    16819 <   cancellations FK_cancellations_appointmentid_appointments_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.cancellations
    ADD CONSTRAINT "FK_cancellations_appointmentid_appointments_id" FOREIGN KEY (appointmentid) REFERENCES public.appointments(id);
 h   ALTER TABLE ONLY public.cancellations DROP CONSTRAINT "FK_cancellations_appointmentid_appointments_id";
       public          postgres    false    216    214    3213            �           2606    16806 <   consultations FK_consultations_appointmentid_appointments_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.consultations
    ADD CONSTRAINT "FK_consultations_appointmentid_appointments_id" FOREIGN KEY (appointmentid) REFERENCES public.appointments(id);
 h   ALTER TABLE ONLY public.consultations DROP CONSTRAINT "FK_consultations_appointmentid_appointments_id";
       public          postgres    false    3213    214    215            �           2606    16745 7   dentistes FK_dentistes_workcategoryid_workcategories_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.dentistes
    ADD CONSTRAINT "FK_dentistes_workcategoryid_workcategories_id" FOREIGN KEY (workcategoryid) REFERENCES public.workcategories(id);
 c   ALTER TABLE ONLY public.dentistes DROP CONSTRAINT "FK_dentistes_workcategoryid_workcategories_id";
       public          postgres    false    3207    211    212            '   s  x��WM��=
\w߅`l�]fc�s��_S�F�o�W��m:J�S@Q��i�Mc�I&���Q$3�7m_ʪąؾ���|/�.�,'�WRϾ�l����T�N}�CۧQx��\�s[v�l�*sT��������ȑã|�o�-Q����dV�èV ����@�7���̎4�����;�#�[u�ӿ<<����,�.�;���i�p�R'G��0qkrٔ>F��Ӣ�T������6�t���q^^ڙuI)_���v�T�Ȫ&�L��e�@} J�f�'�3�~��H��g�vܢ�q��p��tT�ĖҰ��:�:e��`����]�x��4� h�}�����Y;�V��Zm�$d���\�W��ХI`y�'u�@*�8f�а�]c�b���"`/NxP�{��_&�p�� ���m����Li��U��'O��:$6���|+���)��g�]���Z~*o GA�A�n����Z�J���	�����@�Dh��d��s��1��nZ��yZ��q'��aa���m��$��,����i^������T Ӂ��@q�X4jn�&�7�r�rP�A<;FC6���0�"r��n�? ��KjE5�\�7a�Mk�n"F�g��V��g�:�YX[�M�E�Ј���8�{.����$�cr�z�m�<�����%-7�+^�U��\V���O�=��-۵���]�w�Ic4|ż�e�E�?�=$;8�ɺ����U^T3gCo!�켵�^�H�l�UN��z����M��#�j��:�f+�EF��>�db�������q�@�,3]�֍�%r�6.�f&6��9@"�nW�Q9�<ލP��͞��+�I�.������&�,MgG������!�p(��sbl�"���g�i�Uñ61��
�������%�� �k'��Z|�r(>��4�r�~� Ϩ!�f��ձ������5�)��sO��mi(?I�̲b�v�W����V�Ɔ`����: ��� z7n��Ϲ�N(�]�S���:��e�,Z,Ё��9-Ka�}�o� �IU�����n%Ё����;�g�<Z~>��$����k�'Vs��4�� �L�����/��N��!���G~ >ڭ����,~��?$T_�w�W��KW��#��%놗��?��� �۪�{C��{���֨�v�т3��pFp�|x�v� ��]�/a����J��2�w�ܔc�mo-���n���Y���	����d��`�[/ �W�*e\E�WXy�7�3^P����7�f��2C�F�k�p�w����w�O���)�<Y*�<��Ȣ��I7����� }�=R�,�Xq����Qv�����
��?����S�=      )     x����jAE�ݯ�P��Q�;�&��i�I�����d�nST$r͖��1ރm�A�CHڱ�bEg=h���0}�7�+�%��)������^.��ܿ�rW�
�KD��8#X��tٌ�s�똇�,��:���6c�(�B`�#��a���8���Am�����c����Pt)���R��J�X�Z�V�mD�D�7(l��GCj��Qt،�B�꒗d�BϾ��V0�@RbCN��ƾ��M���|YSB7g�0D���(�.��f�8�Rj���i�}Z      &   �   x�U�=N1�:s�����8�rJ'�H0+�fW�\�#pn�I��I���]��D��=H�* ��tK�[1�Ϗ!�8�IWC���W� 87��c���������!}��cm_o��]�*G���uA�T
p��Ka�ؘ��9|�C��EF?�N�k������{�3O<�Xj�rA� k
��x�@NR6��sQ����Is��ݲ,�e�V�      (   �   x���1N�@��:9E.`�=���@�����'c����n�/R!*D���O<��;���dpE���B}tΉ�P ����?�e�~�o�~�,y�//��u�_�r,o�U
E��Wo J�J�5�f"�e��hVO�6��iqth�)h*gm��]i��/��xej�1{$�AL%�X�Y�lbR�l!�������bP�п3�	��� ����A3Z
&՜?��y��ec'      %   �   x�m�KjC1���*�I�e{�B�щe�%д�d��)�4$�{�S�X%���Jf�luxW+�ۛ]��h{'?�w�6~l���7���u�����6l���A�j"����إO-�Nv�u��Ʉ�뉌r�s�v�����%�D��!���5ġd��	[+S��荬���� Z4*�٬k�z��I���'��Yb�9gXi�`�	�'��<>,��C?E[x�      #   �  x���K��F@�=��hY�w1�1 �x��ԇ0��A�M.�|��ۄ�qk)��P����"%�W�* �XG��<��|;�����^�p������8����?\.�ߎW�ڇ��Ew:p��<�E�u4_���@�����+�VZph�CgNnIS�,�h	�)BQTp=�8Z�����W����߽�#����!�#G`���]&n������+/H�A�sF\�Qq	��m�zP]��,O����',8a��fT���r?���%�E��7F��W�� �R<gTIZT$�Ae��*��ҕ�V���N��܈ҺCp"
,�B�����~8�Qܕ�W����N>s0t/T�E�l;J���2��3��ʑG����M9��:;�X��j�'��:��rծnٯn��SRN��l�o�YQSH���Q5�Q8�\޸a���a�r���;��DM\i@���[F+�\�ŵp��^Q�Vm�A?�.��΀y4�s1Q��km\*7a!�W��R0�D���%�x�(1�0ͨ�"p��h^�9��T
	��^�A�[ʗZ��_h|m	ߎ���	[���Y�i��Feu���3j�	\z7Da!��HT1s���c�*l�Y�L����p�
\�7l�_m!�����j��j5�LФc�rL:�ֺ��/pCxF���cV�3������`�/�a���kc�R���:������Y}$�*Ԡ54E"_�ɻv-�Aΰ�LkVˤوB�bnS=hA�����w�J��/�������4M���O�O�>�9|�hz�����8|9E<�(��)������-6�$�^�v{�mUX�lԔ�����'}������3�o����������X��ˣ��}@�jc�Sq�\nAyww����'ԝ>>]yZ.n>�7�����Ϳ���      $   �   x�5ͻ1���E%˒� +�L���#ė� �`�����!�f�����	d�Z�-��[�p�u�ND�)�$�]��S��iHB��}Y�,��3�l˂���2�媄��d���.������#��ؤ*     