
CREATE TABLE ������� (
  ID_������� INT PRIMARY KEY,
  ��� VARCHAR(255) NOT NULL,
  ����� VARCHAR(255)
);

CREATE TABLE ����� (
  �����_����� INT PRIMARY KEY,
  ID_������� INT REFERENCES �������(ID_�������),
  ���_����� VARCHAR(255),
  ������ DECIMAL(10, 2) DEFAULT 0.00
);

CREATE TABLE ������� (
  ID_������� INT PRIMARY KEY,
  �������_������ INT REFERENCES �����(�����_�����),
  �����_������� DECIMAL(10, 2) NOT NULL,
  ����������_������ DECIMAL(5, 2) NOT NULL,
  ����_��������� INT NOT NULL,
  �����������_������ DECIMAL(10, 2)
);

CREATE TABLE �������_��_�������� (
  ID_�������_������� INT PRIMARY KEY,
  ������ INT REFERENCES �������(ID_�������),
  �����_������� DECIMAL(10, 2) NOT NULL,
  ����_������� DATE
);

CREATE TABLE ���������� (
  ID_���������� INT PRIMARY KEY,
  �������_������ INT REFERENCES �����(�����_�����),
  �����_���������� DECIMAL(10, 2),
  ���_���������� VARCHAR(255),
  ����_���������� DATE
);

CREATE TABLE ���������_����� (
  ID_������ INT PRIMARY KEY,
  ��������_������ VARCHAR(255) NOT NULL,
  �����_������ VARCHAR(255)
);

CREATE TABLE ���������� (
  ID_���������� INT PRIMARY KEY,
  ��� VARCHAR(255) NOT NULL,
  ��������� VARCHAR(255),
  ����� INT REFERENCES ���������_�����(ID_������)
);
