package com.sysmap.parrot.application.fileUpload;

import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.model.CannedAccessControlList;
import com.amazonaws.services.s3.model.PutObjectRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Objects;

@Service
public class AwsService {

    @Autowired
    private AmazonS3 amazonS3;

    @Value("${s3.endpointUrl}")
    private String endpointUrl;
    @Value("${s3.bucketName}")
    private String bucketName;


    public String upload(MultipartFile multipartFile, String fileName) throws Exception {
        var fileUrl = "";

        try {
            var file = convertMultiPartToFile(multipartFile);

            uploadFileToS3(file, fileName);

            fileUrl = endpointUrl + "/" + bucketName + "/" + fileName;

            file.delete();

        } catch (Exception e) {
            throw new Exception(e.getMessage());
        }

        return fileUrl;
    }

    private void uploadFileToS3(File file, String fileName) throws IOException {
        try {
            amazonS3.putObject(new PutObjectRequest(bucketName, fileName, file).withCannedAcl(CannedAccessControlList.PublicRead));
        } catch (Exception e) {
            throw new IOException(e);
        }
    }

    private File convertMultiPartToFile(MultipartFile file) throws IOException {
        var convFile = new File(Objects.requireNonNull(file.getOriginalFilename()));

        var fos = new FileOutputStream(convFile);

        fos.write(file.getBytes());
        fos.close();

        return convFile;
    }
}
